using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace UserDesignForm
{
    class LoadRunLayout
    {

        public void ReadLayout(Control f)
        {
            MemoryStream s = SaveLoadLayout.LoadFormDB(f.Name);
            if (s == null) return;
            StreamReader sr = new StreamReader(s);
            string cleandown = sr.ReadToEnd();

            cleandown = "<DOCUMENT_ELEMENT>" + cleandown + "</DOCUMENT_ELEMENT>";

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(cleandown);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                
                if (node.Name.Equals("Object"))
                {
                    ReadObject(node, f);
                }

            }
        }

        private Control FindControl(Control f, string contrlname)
        {            
            if (f.Name == contrlname) return f;
            foreach (Control c in f.Controls)
            {
                if (c.Name == contrlname) return c;
            }
            return null;
        }

        //private IComponent FinComponent(Control f, string contrlname)
        //{
        //    foreach (Control c in f.com)
        //    {
        //        if (c.Name == contrlname) return c;
        //    }
        //    return null;
        //}

        private void ReadObject(XmlNode node, Control f)
        {
            //XmlAttribute typeAttr = node.Attributes["type"];
            //Type type = Type.GetType(typeAttr.Value);

            foreach (XmlNode childNode in node.ChildNodes)
            {

                if (childNode.Name.Equals("Object"))
                {
                    
                    Control m = FindControl(f, childNode.Attributes["name"].Value);
                    
                    if (m != null)
                    {
                        ReadObject(childNode, f);
                    }
                    else
                    {
                        XmlAttribute typeAttr = childNode.Attributes["type"];
                        Type type = Type.GetType(typeAttr.Value);
                        Control newControl = (Control)Activator.CreateInstance(type);
                        newControl.Name = childNode.Attributes["name"].Value;
                        f.Controls.Add(newControl);
                        ReadObject(childNode, f);
                    }
                }
                else if (childNode.Name.Equals("Property"))
                {
                    Control m = FindControl(f, node.Attributes["name"].Value);
                    if (m != null)
                    {
                        ReadProperty(childNode, m);
                    }
                    else
                    {
                         //MessageBox.Show(f.GetType().ToString());
                        // XmlAttribute typeAttr = childNode.Attributes["type"];
                        // Type type = Type.GetType(typeAttr.Value);
                        // Activator.CreateInstance(type);
                    }
                }
            }
        }

        private void ReadProperty(XmlNode node, object instance)
        {
            XmlAttribute nameAttr = node.Attributes["name"];
            PropertyDescriptor prop = TypeDescriptor.GetProperties(instance)[nameAttr.Value];
            bool isContent = prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content);
            if (isContent)
            {
                
                object value = prop.GetValue(instance);
                if (value is IList)
                {
                }
                else
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.Equals("Property"))
                        {
                            ReadProperty(child, value);
                        }
                    }
                }
            }
            else
            {
                object value;

                if (ReadValue(node, prop.Converter, out value))
                {
                    try
                    {
                        prop.SetValue(instance, value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private bool ReadValue(XmlNode node, TypeConverter converter, out object value)
        {
            try
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.NodeType == XmlNodeType.Text)
                    {
                        value = converter.ConvertFromInvariantString(node.InnerText);
                        return true;
                    }
                    else if (child.Name.Equals("Binary"))
                    {
                        byte[] data = Convert.FromBase64String(child.InnerText);

                        // Binary blob.  Now, check to see if the type converter
                        // can convert it.  If not, use serialization.
                        //
                        if (GetConversionSupported(converter, typeof(byte[])))
                        {
                            value = converter.ConvertFrom(null, CultureInfo.InvariantCulture, data);
                            return true;
                        }
                        else
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream(data);

                            value = formatter.Deserialize(stream);
                            return true;
                        }
                    }
                    else if (child.Name.Equals("InstanceDescriptor"))
                    {
                        value = ReadInstanceDescriptor(child);
                        return (value != null);
                    }
                    else
                    {
                        value = null;
                        return false;
                    }
                }

                value = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                value = null;
                return false;
            }
        }

        private object ReadInstanceDescriptor(XmlNode node)
        {
            // First, need to deserialize the member
            //
            XmlAttribute memberAttr = node.Attributes["member"];

            if (memberAttr == null)
            {
                return null;
            }

            byte[] data = Convert.FromBase64String(memberAttr.Value);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(data);
            MemberInfo mi = (MemberInfo)formatter.Deserialize(stream);
            object[] args = null;

            // Check to see if this member needs arguments.  If so, gather
            // them from the XML.
            if (mi is MethodBase)
            {
                ParameterInfo[] paramInfos = ((MethodBase)mi).GetParameters();

                args = new object[paramInfos.Length];

                int idx = 0;

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.Equals("Argument"))
                    {
                        object value;

                        if (!ReadValue(child, TypeDescriptor.GetConverter(paramInfos[idx].ParameterType), out value))
                        {
                            return null;
                        }

                        args[idx++] = value;
                    }
                }

                if (idx != paramInfos.Length)
                {
                    //errors.Add(string.Format("Member {0} requires {1} arguments, not {2}.", mi.Name, args.Length, idx));
                    return null;
                }
            }

            InstanceDescriptor id = new InstanceDescriptor(mi, args);
            object instance = id.Invoke();

            // Ok, we have our object.  Now, check to see if there are any properties, and if there are, 
            // set them.
            //
            foreach (XmlNode prop in node.ChildNodes)
            {
                if (prop.Name.Equals("Property"))
                {
                    ReadProperty(prop, instance);
                }
            }

            return instance;
        }

        private bool GetConversionSupported(TypeConverter converter, Type conversionType)
        {
            return (converter.CanConvertFrom(conversionType) && converter.CanConvertTo(conversionType));
        }

    }
}
