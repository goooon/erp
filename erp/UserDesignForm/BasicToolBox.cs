using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace UserDesignForm
{
    public class BasicToolBox : ListBox, IToolboxService
    {
        private IDesignerHost m_designerHost;
        private int selectedIndex = 0;

        public IDesignerHost DesignerHost
        {

            set { m_designerHost = value; }

            get { return m_designerHost; }

        }


        public BasicToolBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;

            this.SelectionMode = SelectionMode.One;

            this.populateItems();

        }

        private void AddToolBox(Type type,Type TypeBmp,string DisplayName)
        {
            ToolboxItem toolboxItem = new ToolboxItem(type);
            
            toolboxItem.DisplayName = DisplayName;

            System.Drawing.ToolboxBitmapAttribute tba =
                  TypeDescriptor.GetAttributes(TypeBmp)[typeof(System.Drawing.ToolboxBitmapAttribute)]
                        as System.Drawing.ToolboxBitmapAttribute;

            Bitmap bmp = (System.Drawing.Bitmap)tba.GetImage(TypeBmp);
            toolboxItem.Bitmap = bmp;
            this.Items.Add(toolboxItem);

        }


        private void populateItems()
        {
            ToolboxItem pointer = new System.Drawing.Design.ToolboxItem();
            pointer.DisplayName = "<Pointer>";
            pointer.Bitmap = new System.Drawing.Bitmap(16, 16);
            this.Items.Add(pointer);

            AddToolBox(typeof(myControl.cbControl),typeof(ComboBox),"下拉列表");
            AddToolBox(typeof(myControl.ckControl), typeof(CheckBox),"复选框");
            AddToolBox(typeof(myControl.DateControl), typeof(DateTimePicker),"日期");
            AddToolBox(typeof(myControl.EditControl), typeof(TextBox),"文本框");
            AddToolBox(typeof(myControl.lupControl), typeof(ComboBox),"下拉查询");
            AddToolBox(typeof(myControl.SpinControl), typeof(MaskedTextBox),"数值编辑框");
           
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            try
            {
                if (e == null)
                    return;

                // If this tool is the currently selected tool, draw it with a highlight.
                if (selectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds);
                }

                
                System.Drawing.Design.ToolboxItem tbi = this.Items[e.Index] as System.Drawing.Design.ToolboxItem;
                Rectangle BitmapBounds = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y + e.Bounds.Height / 2 - tbi.Bitmap.Height / 2, tbi.Bitmap.Width, tbi.Bitmap.Height);
                Rectangle StringBounds = new Rectangle(e.Bounds.Location.X + BitmapBounds.Width + 5, e.Bounds.Location.Y, e.Bounds.Width - BitmapBounds.Width, e.Bounds.Height);

                StringFormat format = new StringFormat();

                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Near;
                e.Graphics.DrawImage(tbi.Bitmap, BitmapBounds);
                e.Graphics.DrawString(tbi.DisplayName, new Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.World), Brushes.Black, StringBounds, format);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            base.OnDrawItem(e);

        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {

                if (this.SelectedIndex == -1) return;
                Rectangle lastSelectedBounds = this.GetItemRectangle(0);
                try
                {
                    lastSelectedBounds = this.GetItemRectangle(selectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误");
                }

                selectedIndex = this.SelectedIndex;
                //selectedIndex = this.IndexFromPoint(e.X, e.Y); // change our selection
                //this.SelectedIndex = selectedIndex;
                this.Invalidate(lastSelectedBounds); // clear highlight from last selection
                this.Invalidate(this.GetItemRectangle(selectedIndex)); // highlight new one

                if (selectedIndex != 0)
                {
                    if (e.Clicks == 2)
                    {
                        //IDesignerHost idh = (IDesignerHost)this.DesignerHost.GetService(typeof(IDesignerHost));
                        //IToolboxUser tbu = idh.GetDesigner(idh.RootComponent as IComponent) as IToolboxUser;

                        //if (tbu != null)
                        //{
                        //    tbu.ToolPicked((System.Drawing.Design.ToolboxItem)(this.Items[selectedIndex]));
                        //}
                    }
                    else if (e.Clicks < 2)
                    {
                        ToolboxItem tbi = this.Items[selectedIndex] as ToolboxItem;

                        // The IToolboxService serializes ToolboxItems by packaging them in DataObjects.
                        DataObject d = this.SerializeToolboxItem(tbi) as DataObject;

                        try
                        {
                            this.DoDragDrop(d, DragDropEffects.Copy);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"错误");
            }

            base.OnMouseDown(e);
        }

        #region IToolboxService Members

        // We only implement what is really essential for ToolboxService

        public ToolboxItem GetSelectedToolboxItem(IDesignerHost host)
        {
            System.Drawing.Design.ToolboxItem tbi = (System.Drawing.Design.ToolboxItem)this.Items[selectedIndex];
            if (tbi.DisplayName != "<Pointer>")
                return tbi;
            else
                return null;
        }

        public System.Drawing.Design.ToolboxItem GetSelectedToolboxItem()
        {
            return this.GetSelectedToolboxItem(null);
        }

        public void AddToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category)
        {
        }

        public void AddToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
        }

        public bool IsToolboxItem(object serializedObject, IDesignerHost host)
        {
            return false;
        }

        public bool IsToolboxItem(object serializedObject)
        {
            return false;
        }

        public void SetSelectedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
        }

        public void SelectedToolboxItemUsed()
        {
            ListBox list = this;

            list.Invalidate(list.GetItemRectangle(selectedIndex));
            selectedIndex = 0;
            list.SelectedIndex = 0;
            list.Invalidate(list.GetItemRectangle(selectedIndex));
        }

        public CategoryNameCollection CategoryNames
        {
            get
            {
                return null;
            }
        }

        void IToolboxService.Refresh()
        {
        }

        public void AddLinkedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category, IDesignerHost host)
        {
        }

        public void AddLinkedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, IDesignerHost host)
        {
        }

        public bool IsSupported(object serializedObject, ICollection filterAttributes)
        {
            return false;
        }

        public bool IsSupported(object serializedObject, IDesignerHost host)
        {
            return false;
        }

        public string SelectedCategory
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public System.Drawing.Design.ToolboxItem DeserializeToolboxItem(object serializedObject, IDesignerHost host)
        {
            return (System.Drawing.Design.ToolboxItem)((DataObject)serializedObject).GetData(typeof(System.Drawing.Design.ToolboxItem));
        }

        public System.Drawing.Design.ToolboxItem DeserializeToolboxItem(object serializedObject)
        {
            return this.DeserializeToolboxItem(serializedObject, this.DesignerHost);
        }

        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(string category, IDesignerHost host)
        {
            return null;
        }

        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(string category)
        {
            return null;
        }

        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(IDesignerHost host)
        {
            return null;
        }

        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems()
        {
            return null;
        }

        public void AddCreator(ToolboxItemCreatorCallback creator, string format, IDesignerHost host)
        {
        }

        public void AddCreator(ToolboxItemCreatorCallback creator, string format)
        {
        }

        public bool SetCursor()
        {
            return false;
        }

        public void RemoveToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category)
        {
        }

        public void RemoveToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
        }

        public object SerializeToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
            return new DataObject(toolboxItem);
        }

        public void RemoveCreator(string format, IDesignerHost host)
        {
        }

        public void RemoveCreator(string format)
        {
        }

        #endregion


    } 

}
