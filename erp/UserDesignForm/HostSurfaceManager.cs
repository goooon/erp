using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace UserDesignForm
{
    //public enum LoaderType
    //{
    //    BasicDesignerLoader = 1,
    //    CodeDomDesignerLoader = 2,
    //    NoLoader = 3
    //}

    /// <summary>
    /// Manages numerous HostSurfaces. Any services added to HostSurfaceManager
    /// will be accessible to all HostSurfaces
    /// </summary>
	public class HostSurfaceManager : DesignSurfaceManager
	{
		public HostSurfaceManager() : base()
		{
			this.AddService(typeof(INameCreationService), new NameCreationService());
            this.ActiveDesignSurfaceChanged += new ActiveDesignSurfaceChangedEventHandler(HostSurfaceManager_ActiveDesignSurfaceChanged);
		}

		protected override DesignSurface CreateDesignSurfaceCore(IServiceProvider parentProvider)
		{
			return new HostSurface(parentProvider);
		}

        /// <summary>
        /// Gets a new HostSurface and loads it with the appropriate type of
        /// root component. 
        /// </summary>
        //private HostControl GetNewHost(Type rootComponentType)
        //{
        //    HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);

        //    if (rootComponentType == typeof(Form))
        //        hostSurface.BeginLoad(typeof(Form));
        //    else if (rootComponentType == typeof(UserControl))
        //        hostSurface.BeginLoad(typeof(UserControl));
        //    else if (rootComponentType == typeof(Component))
        //        hostSurface.BeginLoad(typeof(Component));
        //    //else if (rootComponentType == typeof(MyTopLevelComponent))
        //    //    hostSurface.BeginLoad(typeof(MyTopLevelComponent));
        //    else
        //        throw new Exception("Undefined Host Type: " + rootComponentType.ToString());

        //    hostSurface.Initialize();
        //    this.ActiveDesignSurface = hostSurface;
        //    return new HostControl(hostSurface);
        //}

        /// <summary>
        /// Gets a new HostSurface and loads it with the appropriate type of
        /// root component. Uses the appropriate Loader to load the HostSurface.
        /// </summary>
        //public HostControl GetNewHost(Type rootComponentType)
        //{

        //    HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);
        //    IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));

        //    BasicHostLoader basicHostLoader = new BasicHostLoader(rootComponentType);
        //    hostSurface.BeginLoad(basicHostLoader);
        //    hostSurface.Loader = basicHostLoader;
        //    hostSurface.Initialize();
        //    return new HostControl(hostSurface);
        //}

        private Type GetType(string sClass, string sForm)
        {
            Assembly _Assembly = Assembly.Load(sClass);
            Type _FormType = _Assembly.GetType(sClass+"."+sForm, true, true);
            return _FormType;
        }

        /// <summary>
        /// Opens an Xml file and loads it up using BasicHostLoader (inherits from
        /// BasicDesignerLoader)
        /// </summary>
		public HostControl GetNewHost(string sClass,string formName)
		{
			HostSurface hostSurface = (HostSurface)this.CreateDesignSurface(this.ServiceContainer);
			IDesignerHost host = (IDesignerHost)hostSurface.GetService(typeof(IDesignerHost));
            
            BasicHostLoader basicHostLoader = null;
            if (SaveLoadLayout.TestFormat(formName) == false)
                basicHostLoader = new BasicHostLoader(GetType(sClass,formName),formName);
            else
                basicHostLoader = new BasicHostLoader(formName);
            hostSurface.BeginLoad(basicHostLoader);
            hostSurface.Loader = basicHostLoader;
    		hostSurface.Initialize();
			return new HostControl(hostSurface);
		}

		public void AddService(Type type, object serviceInstance)
		{
			this.ServiceContainer.AddService(type, serviceInstance);
		}

        /// <summary>
        /// Uses the OutputWindow service and writes out to it.
        /// </summary>
		void HostSurfaceManager_ActiveDesignSurfaceChanged(object sender, ActiveDesignSurfaceChangedEventArgs e)
		{
            //ToolWindows.OutputWindow o = this.GetService(typeof(ToolWindows.OutputWindow)) as ToolWindows.OutputWindow;
            //o.RichTextBox.Text += "New host added.\n";
		}
	}// class
}// namespace
