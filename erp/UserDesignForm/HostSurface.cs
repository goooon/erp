using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace UserDesignForm 
{
    /// <summary>
    /// Inherits from DesignSurface and hosts the RootComponent and 
    /// all other designers. It also uses loaders (BasicDesignerLoader
    /// or CodeDomDesignerLoader) when required. It also provides various
    /// services to the designers. Adds MenuCommandService which is used
    /// for Cut, Copy, Paste, etc.
    /// </summary>
	public class HostSurface : DesignSurface
	{
		private BasicDesignerLoader _loader;
		private ISelectionService _selectionService; 

		public HostSurface() : base()
		{
            this.AddService(typeof(IMenuCommandService), new MenuCommandService(this));
		}
		public HostSurface(IServiceProvider parentProvider) : base(parentProvider)
		{
            this.AddService(typeof(IMenuCommandService), new MenuCommandService(this));
        }

		internal void Initialize()
		{

			Control control = null;
			IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

			if (host == null)
				return;
            
			try
			{
                control = this.View as Control;
               
				// Set SelectionService - SelectionChanged event handler
				_selectionService = (ISelectionService)(this.ServiceContainer.GetService(typeof(ISelectionService)));
				_selectionService.SelectionChanged += new EventHandler(selectionService_SelectionChanged);
			}
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

		public BasicDesignerLoader Loader
		{
			get
			{
				return _loader;
			}
			set
			{
				_loader = value;
			}
		}

		/// <summary>
        /// When the selection changes this sets the PropertyGrid's selected component 
		/// </summary>
        private void selectionService_SelectionChanged(object sender, EventArgs e)
		{
			if (_selectionService != null)
			{
				ICollection selectedComponents = _selectionService.GetSelectedComponents();
				PropertyGrid propertyGrid = (PropertyGrid)this.GetService(typeof(PropertyGrid));


				object[] comps = new object[selectedComponents.Count];
				int i = 0;

				foreach (Object o in selectedComponents)
				{
					comps[i] = o;
					i++;
				}

				propertyGrid.SelectedObjects = comps;
			}
		}

		public void AddService(Type type, object serviceInstance)
		{
			this.ServiceContainer.AddService(type, serviceInstance);
		}
	}// class
}// namespace
