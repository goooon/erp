using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace UserDesignForm
{
	/// <summary>
	/// Hosts the HostSurface which inherits from DesignSurface.
	/// </summary>
	public class HostControl : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private HostSurface _hostSurface;

		public HostControl(HostSurface hostSurface)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			InitializeHost(hostSurface);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// HostControl
			// 
			this.Name = "HostControl";
			this.Size = new System.Drawing.Size(268, 224);
		}
		#endregion
	
		internal void InitializeHost(HostSurface hostSurface)
		{
			try
			{
				if (hostSurface == null)
					return;

				_hostSurface = hostSurface;

				Control control = _hostSurface.View as Control;

				control.Parent = this;
				control.Dock = DockStyle.Fill;
				control.Visible = true;
			}
			catch(Exception ex)
			{
                Trace.WriteLine(ex.ToString());
			}
		}
		public HostSurface HostSurface
		{
			get
			{
				return _hostSurface;
			}
		}
		public IDesignerHost DesignerHost
		{
			get
			{
				return (IDesignerHost)_hostSurface.GetService(typeof(IDesignerHost));
			}
		}

	} // class
}// namespace
