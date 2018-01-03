using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Reflection;

namespace UserDesignForm
{
    public partial class DesignForm : Form
    {
        private HostSurfaceManager _hostSurfaceManager = null;
        private string CurrentForm;
        public DesignForm()
        {
            InitializeComponent();
            CustomInitialize();
        }

        private void CustomInitialize()
        {
            _hostSurfaceManager = new HostSurfaceManager();
            BasicToolBox toolBox = new BasicToolBox();
            toolBox.BackColor = Color.FromArgb(236, 233, 216);
            toolBox.BringToFront();
            toolBox.Dock = DockStyle.Fill;
            panel5.Controls.Add(toolBox);
            _hostSurfaceManager.AddService(typeof(IToolboxService), toolBox);
           // _hostSurfaceManager.AddService(typeof(IMenuCommandService), contextMenuStrip1);
            
            //_hostSurfaceManager.AddService(typeof(ToolWindows.SolutionExplorer), this.solutionExplorer1);
            //_hostSurfaceManager.AddService(typeof(ToolWindows.OutputWindow), this.OutputWindow);
            _hostSurfaceManager.AddService(typeof(System.Windows.Forms.PropertyGrid), this.propertyGrid1);
        }

        private void ActionClick(object sender, EventArgs e)
        {
            PerformAction((sender as ToolStripItem).Text);
        }

        private void ToolButtonClick(object sender, EventArgs e)
        {
            PerformAction((sender as ToolStripButton).Text);
        }

        private void AddField(object sender, EventArgs e)
        {
            FieldEditForm F = new FieldEditForm();
            F.ShowDialog();
            F.Dispose();
            //Sys.frmManaField frmEditField = new Sys.frmManaField();
            //frmEditField.ShowDialog();
            //frmEditField.Dispose();
            
        }

        private void PerformAction(string text)
        {

            if (this.GetCurrentHost() == null)
                return;

            IMenuCommandService ims = this.GetCurrentHost().HostSurface.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            try
            {
                switch (text)
                {
                    case "剪切(&T)":
                        ims.GlobalInvoke(StandardCommands.Cut);
                        break;
                    case "复制(&C)":
                        ims.GlobalInvoke(StandardCommands.Copy);
                        break;
                    case "粘贴(&P)":
                        ims.GlobalInvoke(StandardCommands.Paste);
                        break;
                    case "撤消(&U)":
                        ims.GlobalInvoke(StandardCommands.Undo);
                        break;
                    case "重复(&R)":
                        ims.GlobalInvoke(StandardCommands.Redo);
                        break;
                    case "删除(&D)":
                        ims.GlobalInvoke(StandardCommands.Delete);
                        break;
                    case "删除":
                        ims.GlobalInvoke(StandardCommands.Delete);
                        break;
                    case "全选(&S)":
                        ims.GlobalInvoke(StandardCommands.SelectAll);
                        break;
                    case "左对齐":
                        ims.GlobalInvoke(StandardCommands.AlignLeft);
                        break;
                    case "居中对齐":
                        ims.GlobalInvoke(StandardCommands.AlignHorizontalCenters);
                        break;
                    case "右对齐":
                        ims.GlobalInvoke(StandardCommands.AlignRight);
                        break;
                    case "顶端对齐":
                        ims.GlobalInvoke(StandardCommands.AlignTop);
                        break;
                    case "中间对齐":
                        ims.GlobalInvoke(StandardCommands.AlignVerticalCenters);
                        break;
                    case "底端对齐":
                        ims.GlobalInvoke(StandardCommands.AlignBottom);
                        break;
                    case "垂直间距相等":
                        ims.GlobalInvoke(StandardCommands.VertSpaceMakeEqual);
                        break;
                    case "水平间距相等":
                        ims.GlobalInvoke(StandardCommands.HorizSpaceMakeEqual);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "错误");
            }
        }


        private HostControl GetCurrentHost()
        {
            if (panel2.Controls.Count == 0) return null;
            return (HostControl)panel2.Controls[0];
        }

        private void OpenForm(object sender, EventArgs e)
        {
            OpenWindow w = new OpenWindow();
            if (w.ShowDialog() == DialogResult.OK)
            {
                CurrentForm = w.tvForm.SelectedNode.Text;
                switch (w.tvForm.SelectedNode.Text)
                {
                    case "供应商资料":
                        LoadForm("Base","frmEditSupplier");
                        break;
                    case "客户资料":
                        LoadForm("Base", "frmEditClient");
                        break;
                    case "外加工厂商":
                        LoadForm("Base", "frmEditOutSupplier");
                        break;
                    case "员工资料":
                        LoadForm("Base", "frmEditEmp");
                        break;
                    case "物料资料":
                        LoadForm("Base", "frmEditItem");
                        break;
                    case "产品资料":
                        LoadForm("Base", "frmEditProduct");
                        break;
                    case "仓库资料":
                        LoadForm("Base", "frmEditProduct");
                        break;
                    case "申购单":
                        LoadForm("Stock", "frmApplyStock");
                        break;
                    case "采购订单":
                        LoadForm("Stock", "frmStockOrder");
                        break;
                    case "采购进货单":
                        LoadForm("Stock", "frmStockIn");
                        break;
                    case "付款单":
                        LoadForm("Stock", "frmStockPay");
                        break;
                    case "采购退货单":
                        LoadForm("Stock", "frmStockBack");
                        break;
                    case "询价单":
                        LoadForm("Sell", "frmAskPrice");
                        break;
                    case "报价单":
                        LoadForm("Sell", "frmSellPrice");
                        break;
                    case "客户订单":
                        LoadForm("Sell", "frmSellOrder");
                        break;
                    case "发货通知单":
                        LoadForm("Sell", "frmSellPre");
                        break;
                    case "发货单":
                        LoadForm("Sell", "frmSellOut");
                        break;
                    case "收款单":
                        LoadForm("Sell", "frmSellAccept");
                        break;
                    case "销售退货单":
                        LoadForm("Sell", "frmSellBack");
                        break;
                    case "客户费用":
                        LoadForm("Sell", "frmEditClientFee");
                        break;
                    case "其它进仓单":
                        LoadForm("Storage", "frmOtherIn");
                        break;
                    case "其它出仓单":
                        LoadForm("Storage", "frmOtherOut");
                        break;
                    case "盘点单":
                        LoadForm("Storage", "frmCheck");
                        break;
                    case "调拔单":
                        LoadForm("Storage", "frmExchange");
                        break;
                    case "拆装单":
                        LoadForm("Storage", "frmInstall");
                        break;

                    case "BOM单":
                        LoadForm("Product", "frmBomEdit");
                        break;
                    case "生产计划单":
                        LoadForm("Product", "frmProductPlan");
                        break;
                    case "生产任务单":
                        LoadForm("Product", "frmTask");
                        break;
                    case "生产状况表":
                        LoadForm("Product", "frmProductStatus");
                        break;
                    case "领料单":
                        LoadForm("Product", "frmDrawGoods");
                        break;
                    case "补料单":
                        LoadForm("Product", "frmPatchGoods");
                        break;
                    case "退料单":
                        LoadForm("Product", "frmBackGoods");
                        break;
                    case "产品进仓单":
                        LoadForm("Product", "frmProductIn");
                        break;

                    case "委外加工单":
                        LoadForm("OutProduct", "frmOutBill");
                        break;
                    case "委外领料单":
                        LoadForm("OutProduct", "frmOutDrawGoods");
                        break;
                    case "委外退料单":
                        LoadForm("OutProduct", "frmOutBackGoods");
                        break;
                    case "委外入库单":
                        LoadForm("OutProduct", "frmOutInStore");
                        break;
                    case "委外退货单":
                        LoadForm("OutProduct", "frmOutBackStore");
                        break;
                    case "委外付款单":
                        LoadForm("OutProduct", "frmOutPay");
                        break;
                }
            }
            w.Dispose();
        }


        private void LoadForm(string sClass,string FormName)
        {
            HostControl hc = _hostSurfaceManager.GetNewHost(sClass,FormName);
            hc.ContextMenuStrip = contextMenuStrip1;
            hc.Parent = panel2;
            hc.Dock = DockStyle.Fill;
            hc.Visible = true;
        }

        private void SaveForm(object sender, EventArgs e)
        {
            if (GetCurrentHost() == null) return;
            ((BasicHostLoader)GetCurrentHost().HostSurface.Loader).Save();
        }

        private void CloseDesign(object sender, EventArgs e)
        {
            if (GetCurrentHost() != null)
               GetCurrentHost().Dispose();

        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }

    }
}
