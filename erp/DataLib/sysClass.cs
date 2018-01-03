using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Data.OleDb;
using DevExpress.XtraReports.UI;
namespace DataLib
{
    public class sysClass
    {
        /// <summary>
        /// 取最大单号
        /// </summary>
        /// <param name="strFlag"></param>
        /// <returns></returns>
        public string GetMaxCode(string strBillTag,string strField,string strFlag)
        {
            DataHelper myHelper = new DataHelper();

            DataSet ds = myHelper.GetDs("exec sp_GetBillCode '" + strBillTag + "','" + strFlag + "','" + strField + "','" + SysVar.strUID + "'");
            //DataSet ds = myHelper.GetDs("exec sp_GetMaxCode '" + strFlag + "','" + SysVar.strUID + "'");
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static DataTable ImportExcel(string strSheet)
        {
            string strFile = DataLib.sysClass.ShowOpenFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile == "") return null;
            if (MessageBox.Show("真的要从选定Excel文件引入数据吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return null;
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source=" + strFile + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            OleDbDataAdapter myCommand = null;
            string strExcel = "select * from [" + strSheet + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataSet dsExcel = new DataSet();
            myCommand.Fill(dsExcel, "table1");
            conn.Close();
            return dsExcel.Tables[0];
        }


        /// <summary>
        /// 给DataTable添加计算字段
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="Field">字段名</param>
        /// <param name="Express">表达式</param>
        public void AddComputerField(DataTable dt, string Field, string Express)
        {
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Decimal");
            dc.ColumnName = Field;
            dc.Expression = Express;
            dt.Columns.Add(dc);
        }

        public void SetColumnDrop(GridColumn gc, string strSQL, string strDispField, string strValueField)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            lupEdit.DataSource = ds.Tables[0].DefaultView;
            lupEdit.ValueMember = strValueField;
            lupEdit.DisplayMember = strDispField;
            lupEdit.ShowFooter = false;
            lupEdit.ShowHeader = false;
            lupEdit.NullText = "";
            gc.ColumnEdit = lupEdit;

        }

        public List<string> SetColumnInfo(GridView gv,string strTable,DataTable dt)
        {
            List<string> s = new List<string>();
            
            string strSQL = "select * from t_SysField where F_TableName = '"+strTable+"'";
            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                bool bNull = true;
                if (dr["F_Null"] != DBNull.Value) bNull = Convert.ToBoolean(dr["F_Null"]);

                if (dt.Columns.Contains(dr["F_FieldName"].ToString()) == true && bNull == false)
                    s.Add(dr["F_FieldName"].ToString());
                   //dt.Columns[dr["F_FieldName"].ToString()].AllowDBNull = bNull;

                if (dr["F_Type"].ToString() == "计算字段")
                {
                    AddComputerField(dt, dr["F_FieldName"].ToString(), dr["F_Express"].ToString());
                }

                if (gv != null)
                {
                    GridColumn gc = gv.Columns.ColumnByFieldName(dr["F_FieldName"].ToString());
                    if ( gc != null)
                    {
                        if (dr["F_SQL"] != DBNull.Value)
                        {
                            SetColumnDrop(gc, dr["F_SQL"].ToString(), dr["F_DispField"].ToString(), dr["F_ValueField"].ToString());
                        }
                    }
                }
            }
            return s;
        }


        /// <summary>
        /// 保存文件到大二进制字段
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="intFlag"></param>
        public void SaveFileToDr(DataRow dr,int intFlag)
        {
            OpenFileDialog F = new OpenFileDialog();
            if (F.ShowDialog() == DialogResult.No) return;
            string[] str = F.FileName.Split('\\');
            string sFile = str[str.Length - 1];
            FileStream s = File.OpenRead(F.FileName);
            byte[] bytes = new byte[s.Length];
            s.Read(bytes, 0, Convert.ToInt32(s.Length));

            dr.BeginEdit();
            dr["F_FileName" + intFlag.ToString()] = sFile;
            dr["F_File" + intFlag.ToString()] = bytes;
            dr.EndEdit();
            s.Close();
        }

        /// <summary>
        /// 从大二进制字段读出文件
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="intFlag"></param>
        public void LoadFileFromDr(DataRow dr, int intFlag)
        {
            if (dr["F_FileName" + intFlag.ToString()] == DBNull.Value)
            {
                MessageBox.Show("没有附件！", "提示");
                return;
            }
            string sFile = dr["F_FileName" + intFlag.ToString()].ToString();
            byte[] File = (byte[])dr["F_File" + intFlag.ToString()];

            if (System.IO.Directory.Exists("C:\\AccessTmp"+intFlag.ToString()) == false)
            {
                System.IO.Directory.CreateDirectory("C:\\AccessTmp" + intFlag.ToString());
            }
            else
            {
                System.IO.Directory.Delete("C:\\AccessTmp" + intFlag.ToString(), true);
                System.IO.Directory.CreateDirectory("C:\\AccessTmp" + intFlag.ToString());
            }

            FileStream fs = new FileStream("C:\\AccessTmp"+ intFlag.ToString() +"\\"+ sFile, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(File, 0, File.Length);
            bw.Close();
            fs.Close();

            Process p = new Process();
            p.StartInfo.FileName = "C:\\AccessTmp"+intFlag.ToString() + "\\" + sFile;
            try
            {
                p.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "错误");
            }
        }

        /// <summary>
        /// 从大二进制字段读出文件
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="intFlag"></param>
        public void LoadFileFromDr(DataRow dr, string sFileNameField,string sFileField)
        {
            if (dr[sFileNameField] == DBNull.Value)
            {
                MessageBox.Show("没有附件！", "提示");
                return;
            }
            string sFile = dr[sFileNameField].ToString();
            byte[] File = (byte[])dr[sFileField];

            if (System.IO.Directory.Exists("C:\\AccessTmp") == false)
            {
                System.IO.Directory.CreateDirectory("C:\\AccessTmp");
            }
            else
            {
                System.IO.Directory.Delete("C:\\AccessTmp", true);
                System.IO.Directory.CreateDirectory("C:\\AccessTmp");
            }

            FileStream fs = new FileStream("C:\\AccessTmp" + "\\" + sFile, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(File, 0, File.Length);
            bw.Close();
            fs.Close();

            Process p = new Process();
            p.StartInfo.FileName = "C:\\AccessTmp" + "\\" + sFile;
            try
            {
                p.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "错误");
            }
        }

        /// <summary>
        /// 取得随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandom()
        {
            string strValue = "";
            Random rd = new Random();
            for (int i = 0; i < 13; i++)
            {
                strValue = strValue + rd.Next(1, 10).ToString();
            }
            return strValue;
        }

        public static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "引出到 " + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        public static string ShowOpenFileDialog(string title, string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开" + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }


        /// <summary>
        /// 根据物料编码得到结果行(DataRow)
        /// </summary>
        /// <param name="strItemID"></param>
        /// <returns></returns>
        public DataRow FindItem(string strItemID)
        {
            string strSQL = "";

            strSQL = "select a.*,(select F_Name from t_Class where F_ID = a.F_Type) as F_TypeName,b.F_Name as F_Unit from t_Item a ";
            strSQL = strSQL + "left join t_Unit b ";
            strSQL = strSQL + "on a.F_ID = b.F_ItemID ";
            strSQL = strSQL + "and b.F_Main = 1 ";
            strSQL = strSQL + "where (a.F_ID = '" + strItemID + "' or F_BarCode = '" + strItemID + "')";

            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("无此物料,请查证!!", "提示");
                return null;
            }
            return ds.Tables[0].Rows[0];
        }

        /// <summary>
        /// 取得物料资料
        /// </summary>
        /// <param name="strItemID"></param>
        public bool GetItem(string strItemID, int intFlag, DataRow drCurrent, string strTag)
        {
            bool blnFlag = false;
            DataRow dr = FindItem(strItemID);

            if (dr == null) return false;

            DataTable dt = drCurrent.Table;

            DataRow drItem;
            if (intFlag == 0)
                drItem = drCurrent;
            else
            {
                drItem = drCurrent;
                if (drItem["F_ItemID"] != DBNull.Value)
                {
                    drItem = dt.NewRow();
                    blnFlag = true;
                }
            }

            drItem["F_ItemID"] = dr["F_ID"];
            drItem["F_ItemName"] = dr["F_Name"];
            drItem["F_Spec"] = dr["F_Spec"];
            drItem["F_Unit"] = dr["F_Unit"];
            if (dt.Columns.Contains("F_StorageID") == true)
                drItem["F_StorageID"] = dr["F_StorageID"];

            if (dt.Columns.Contains("F_Brand") == true)
                drItem["F_Brand"] = dr["F_Brand"];

            if (dt.Columns.Contains("F_Grade") == true)
                drItem["F_Grade"] = dr["F_Grade"];

            if (dt.Columns.Contains("F_Type") == true)
                drItem["F_Type"] = dr["F_TypeName"];

            if (dt.Columns.Contains("F_Color") == true)
                drItem["F_Color"] = dr["F_Color"];

            if (dt.Columns.Contains("F_SupplierID") == true)
                drItem["F_SupplierID"] = dr["F_SupplierID"];

            if (dt.Columns.Contains("F_Material") == true)
                drItem["F_Material"] = dr["F_Material"];

            if (strTag == "frmStockOrder" || strTag == "frmStockIn" ||
                strTag == "frmStockBack" || strTag == "frmStockInStore")
            {
                drItem["F_Price"] = dr["F_StockPrice"];
            }

            if (strTag == "frmSellOrder" || strTag == "frmSellOut" ||
                strTag == "frmSellBack")
            {
                if (drItem["F_Price"] == DBNull.Value)
                   drItem["F_Price"] = dr["F_SellPrice"];
            }

            if (strTag == "frmDrawGoods" || strTag == "frmPatchGoods" ||
                strTag == "frmBackGoods" || strTag == "frmInstall" ||
                strTag == "frmCheck" || strTag == "frmExchange" ||
                strTag == "frmOtherOut" || strTag == "frmOutDrawGoods" ||
                strTag == "frmOutBackGoods")
            {
                drItem["F_Price"] = dr["F_Price"];
            }

            if (blnFlag == true)
                dt.Rows.Add(drItem);
            else
                drItem.EndEdit();

            return true;
            //SetUnit(strItemID);
        }

        /// <summary>
        /// 取库存某条数据
        /// </summary>
        /// <param name="drStore"></param>
        /// <param name="intFlag"></param>
        /// <param name="drCurrent"></param>
        /// <param name="strTag"></param>
        public void GetStoreItem(DataRow drStore, int intFlag, DataRow drCurrent, string strTag)
        {
            bool blnFlag = false;

            DataTable dt = drCurrent.Table;
            DataRow drItem;
            if (intFlag == 0)
                drItem = drCurrent;
            else
            {
                drItem = drCurrent;
                if (drItem["F_ItemID"] != DBNull.Value)
                {
                    drItem = dt.NewRow();
                    blnFlag = true;
                }
            }
            drItem["F_ItemID"] = drStore["F_ID"];
            drItem["F_ItemName"] = drStore["F_Name"];
            drItem["F_Spec"] = drStore["F_Spec"];
            drItem["F_Unit"] = drStore["F_Unit"];
            drItem["F_Grade"] = drStore["F_Grade"];
            drItem["F_Color"] = drStore["F_Color"];
            drItem["F_BatchNo"] = drStore["F_BatchNo"];

            if (dt.Columns.Contains("F_StorageID") == true)
                drItem["F_StorageID"] = drStore["F_StorageID"];

            if (dt.Columns.Contains("F_Brand") == true)
                drItem["F_Brand"] = drStore["F_Brand"];

            if (dt.Columns.Contains("F_Grade") == true)
                drItem["F_Grade"] = drStore["F_Grade"];

            if (dt.Columns.Contains("F_Type") == true)
                drItem["F_Type"] = drStore["F_TypeName"];

            if (dt.Columns.Contains("F_Color") == true)
                drItem["F_Color"] = drStore["F_Color"];

            if (dt.Columns.Contains("F_Material") == true)
                drItem["F_Material"] = drStore["F_Material"];

            if (dt.Columns.Contains("F_SupplierID") == true)
                drItem["F_SupplierID"] = drStore["F_SupplierID"];

            if (strTag == "frmStockOrder" || strTag == "frmStockIn" ||
                strTag == "frmStockBack")
            {
                drItem["F_Price"] = drStore["F_StockPrice"];
            }

            if (strTag == "frmSellOrder" || strTag == "frmSellOut" ||
                strTag == "frmSellBack")
            {
                if (drItem["F_Price"] == DBNull.Value)
                   drItem["F_Price"] = drStore["F_SellPrice"];
            }

            if (strTag == "frmDrawGoods" || strTag == "frmPatchGoods" ||
                strTag == "frmBackGoods" || strTag == "frmInstall" ||
                strTag == "frmCheck" || strTag == "frmExchange" ||
                strTag == "frmOtherOut" || strTag == "frmOutDrawGoods" ||
                strTag == "frmOutBackGoods")
            {
                if (drItem["F_Price"] == DBNull.Value)
                   drItem["F_Price"] = drStore["F_Price"];
                if (strTag == "frmCheck")
                {
                    drItem["F_ComputerQty"] = drStore["F_Qty"];
                }
            }

            if (blnFlag == true)
                dt.Rows.Add(drItem);
            else
                drItem.EndEdit();
            //SetUnit(drStore["F_ID"].ToString());
        }


        /// <summary>
        /// 测试物料属性权限
        /// </summary>
        /// <returns></returns>
        public string[] GetItemKind()
        {
            string strSQL;
            strSQL = "select a.F_Kind from t_UserKind a,t_User b ";
            strSQL = strSQL + "where a.F_Group = b.F_Group ";
            strSQL = strSQL + "and b.F_ID = '" + SysVar.strUID + "'";
            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            string[] strKind = new string[ds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strKind[i] = dr["F_Kind"].ToString();
                i = i + 1;
            }
            return strKind;
        }

        /// <summary>
        /// 预览
        /// </summary>
        public bool DoPreview(string sCaption, PreviewLocalizer plZer, DevExpress.XtraPrinting.PrintingSystem ps)
        {
            //if (ChechRight(sCaption) == false)
            //   return false;

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                PreviewLocalizer.Active = plZer;
                //标题
                PageHeaderFooter phf = ps.Links[0].PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                phf.Header.Content.AddRange(new string[] { SysVar.strCompany, sCaption, "" });
                
                ps.Links[0].CreateDocument();

                ps.Links[0].ShowPreview();
                Cursor.Current = currentCursor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return false;
            }
            return true;
        }


        /// <summary>
        /// 预览
        /// </summary>
        public bool DoPreview2(string sCaption, DevExpress.XtraPrinting.PrintingSystem ps)
        {
            //if (ChechRight(sCaption) == false)
            //   return false;

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                // PreviewLocalizer.Active = plZer;
                DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
                //标题
                PageHeaderFooter phf = ps.Links[0].PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                phf.Header.Content.AddRange(new string[] { SysVar.strCompany, sCaption, "" });

                ps.Links[0].CreateDocument();

                ps.Links[0].ShowPreview();
                Cursor.Current = currentCursor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public bool DoPrint(string sCaption, PreviewLocalizer plZer, DevExpress.XtraPrinting.PrintingSystem ps)
        {
            //if (ChechRight(sCaption) == false)
            //    return false;
            try
            {
                PreviewLocalizer.Active = plZer;
                ps.PrintDlg();
                //ps.Links[0].PrintDlg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return false;
            }
            return true;
        }



        /// <summary>
        /// 打印
        /// </summary>
        public bool DoPrint2(string sCaption, DevExpress.XtraPrinting.PrintingSystem ps)
        {
            //if (ChechRight(sCaption) == false)
            //    return false;
            try
            {
                // PreviewLocalizer.Active = plZer;
                DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();

                ps.PrintDlg();
                //ps.Links[0].PrintDlg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 取得本机ＩＰ
        /// </summary>
        /// <returns></returns>
        public string[] GetIP()
        {
            //Dns.Resolve(Dns.GetHostName());
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());    
            string[] IPInfo = new string[2];
            IPInfo[0] = ipHostInfo.HostName.ToString();
            IPInfo[1] = ipHostInfo.AddressList[0].ToString();
            return IPInfo;
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        public bool TestRight(string strClass)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + strClass + "' and F_Name = '可用' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }


        /// <summary>
        /// 将格式保存入数据库
        /// </summary>
        public static int SaveGridToDB(GridView gv, string sName, int iTag)
        {
            MemoryStream stream = new MemoryStream();
            gv.SaveLayoutToStream(stream);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Format where F_Name = '" + sName + "' and F_Tag = " + iTag.ToString());
            DataRow dr = null;
            if (ds.Tables[0].Rows.Count == 0)
            {
                dr = ds.Tables[0].NewRow();
                dr["F_Name"] = sName;
                dr["F_Tag"] = iTag;
                dr["F_Stream"] = stream.ToArray();
                dr["F_SQL"] = "";
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                dr = ds.Tables[0].Rows[0];
                dr.BeginEdit();
                dr["F_Stream"] = stream.ToArray();
                dr.EndEdit();
            }

            return myHelper.SaveData(ds, "select * from t_Format where F_Name = '" + sName + "' and F_Tag = " + iTag.ToString());
        }

        public static void LoadFormatFromDB(GridView gv, string sName, int iTag)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Format where F_Name = '" + sName + "' and F_Tag = " + iTag.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_Stream"] == DBNull.Value) return;
                MemoryStream stream = new MemoryStream((byte[])ds.Tables[0].Rows[0]["F_Stream"]);
                if (stream != null)
                {
                    gv.RestoreLayoutFromStream(stream);
                }


                gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gv.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
        }


        public static decimal GetSellPrice(string sClientID,string sItemID)
        {
            string sSQL = @"select top 1 b.F_cPrice from t_SellPrice a
                            left join t_SellPriceDetail b
                            on a.F_BillID = b.F_BillID
                            where a.F_ClientID = '"+sClientID+@"' 
                            and b.F_ItemID = '"+sItemID+@"'
                            and ISNULL(b.F_cPrice,0) <> 0
                            order by a.F_Date";

            DataLib.DataHelper myHelper = new DataHelper();
            DataTable dt = myHelper.GetDs(sSQL).Tables[0];
            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0][0]);
            else
                return 0;
        }

    }

}
