using System;
using System.Drawing;
using System.Data;
using System.Text;
using System.Runtime.InteropServices; // 用 DllImport 需用此 命名空间 
using System.Reflection; // 使用 Assembly 类需用此 命名空间 
using System.Reflection.Emit;
using System.Windows.Forms; // 使用 ILGenerator 需用此 命名空间 
using System.Management;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace DataLib
{
    /// <summary> 
    /// 参数传递方式枚举 ,ByValue 表示值传递 ,ByRef 表示址传递 
    /// </summary> 

    public enum ModePass
    {

        ByValue = 0x0001,

        ByRef = 0x0002

    } 

    public class SysVar
    {
        public static string strUrl = "http://localhost/jxcService/Service.asmx";
        public static string strUID = "";   //用户代码
        public static string strUName = "";  //用户名称
        public static string strUGroup = "";  //用户组
        public static string strCon;  //打印连接字符串
        public static string strDB; //当前数据库
        public static string strServer = "localhost\\sqlserver2008";
        public static string strLogID = "sa";
        public static string strLogPsw = "sasql";
        public static string strSysCon = "Data Source=localhost\\sqlserver2008;Initial Catalog=tsJXC;Persist Security Info=True;User ID=sa"; //系统连接字符串
        public static bool blnInit = false; //系统初始化标志 
        public static bool blnSaleMan = false; //业务员标志 
        public static int intConnect = 1;   //连接标识(0:webservice;1:remoting)
        public static int intIndex = 0; //查询日期时段
        public static string strCompany = "";   //公司(打印时用)
        public static string strFactory = "";   //登录厂别
        public static bool blnView = false;   //是否可以查看所有资料
        public static bool blnStorageFlag = false;   //是否通过仓库业务增减库存
        public static bool blnDesignForm = false;  //是否窗体设计模式
        public static string strAccount = ""; //帐套名称
        public static bool bReg = false; //帐套名称
        public static int iReportType = 0; //打印报表类型
        public static string iniFile = "C:\\Set.INI";

        /// </summary> 
        /// <param name="lpFileName">DLL 文件名 </param> 
        /// <returns> 函数库模块的句柄 </returns> 
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        /// </summary> 
        /// <param name="hModule"> 包含需调用函数的函数库模块的句柄 </param> 
        /// <param name="lpProcName"> 调用函数的名称 </param> 
        /// <returns> 函数指针 </returns> 
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);


        /// </summary> 
        /// <param name="hModule"> 需释放的函数库模块的句柄 </param> 
        /// <returns> 是否已释放指定的 Dll</returns> 
        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);


        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

         //打印设计
        [DllImport("RMReport")]
        public static extern int RMDesigner(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue);

        //打印
        [DllImport("RMReport")]
        public static extern int RMPrint(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue, Int32 intCopy);

        //打印预览
        [DllImport("RMReport")]
        public static extern int RMPreview(System.IntPtr handle, string strCon, string strType, string Parm, string ParmValue);

        //自定义财务报表
        [DllImport("cwReport")]
        public static extern int ShowUserReport(System.IntPtr handle, string strCon);

        public SysVar()
        { 
            //string strServer = IniReadValue("Database", "Server", "C:\\Set.Ini");
        }


        /// <summary>
        /// 读取Ini文件参数和值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="filepath"></param>
        public static void IniWriteValue(string Section, string Key, string Value, string filepath)//对ini文件进行写操作的函数
        {
            WritePrivateProfileString(Section, Key, Value, filepath);
        }

        /// <summary>
        /// 写INI文件参数和值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string filepath)//对ini文件进行读操作的函数
        {
            StringBuilder temp = new StringBuilder();
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filepath);
            return temp.ToString();
        }

        /// <summary>
        /// 取得系统参数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static object GetObjParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return ds.Tables[0].Rows[0][0];
        }

        /// <summary>
        /// 取得系统数数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static bool GetParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select "+strField+" from t_parm");
            return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 取得系统数数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static decimal GetDecParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }
        /// <summary>
        /// 取得系统数数
        /// </summary>
        /// <param name="strField"></param>
        /// <returns></returns>
        public static int GetIntParmValue(string strField)
        {
            DataLib.DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs("select " + strField + " from t_parm");
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 取得服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static bool TestCastValid(string sItemID,ref int iDay)
        {
            string sSQL = @"select top 1 DATEDIFF(day,getdate(),a.F_End) as F_Day 
                            from t_Cast a,t_CastDetail b
                            where a.F_ID = b.F_ID
                            and b.F_ItemID = '"+sItemID+@"'
                            and DATEDIFF(day,getdate(),a.F_End) <= 30";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            if (ds.Tables[0].Rows.Count == 0) return false;
            iDay = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Day"]);
            return true;
        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="strModal"></param>
        /// <param name="strLog"></param>
        public static void SetLog(string strModal, string strLog, string strDescribe)
        {
            if (strModal == "设置服务器") return;
            if (strModal == "用户登录") return;
            sysClass myClass = new sysClass();
            string[] strIP = myClass.GetIP();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            String dataTime = DateTime.Now.ToString();// string.Format("{0:yyyyMMdd HHmmss}", DateTime.Now.ToString("yyyy-MM-dd"));
           // dataTime = DateTime.ParseExact(dataTime, "MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            myHelper.ExecuteSQL("insert into t_UserLog(F_Time,F_User,F_Modal,F_Oper,F_Describe,F_Computer,F_IP) values('" + dataTime + "','" + DataLib.SysVar.strUName +"','" + strModal +"','" + strLog +"','" + strDescribe + "','"  + strIP[0] + "','" + strIP[1] + "')");
        }

        /// <summary>
        /// 设置报表列权限
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="strModule">模块名称</param>
        public static void TestColumnRight(DevExpress.XtraGrid.Views.Grid.GridView gv,string strModule)
        {
            string strSQL = "select * from t_DetailRight where F_UID = '"+strUID+"' and F_Module = '"+strModule+"'";
            int intCnt,i;
            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            intCnt = gv.Columns.Count;
            for (i = 0; i < intCnt ; i++)
            {
                DataRow[] drField = ds.Tables[0].Select("F_Field = '" + gv.Columns[i].FieldName + "'");
                if (drField.Length > 0)
                {
                    if (Convert.ToBoolean(drField[0]["F_Visible"]) == false)
                    {
                        gv.Columns[i].Tag = "0";
                        gv.Columns[i].Visible = false;
                    }
                    else
                    {
                        gv.Columns[i].Visible = true;
                    }
                }
                
            }
        }

        public static string[] GetMoc()
        {
            try
            {
                string[] str = new string[2];
                ManagementClass mcCpu = new ManagementClass("win32_Processor");
                if (mcCpu != null)
                {
                    ManagementObjectCollection mocCpu = mcCpu.GetInstances();
                    foreach (ManagementObject m in mocCpu)
                    {
                        str[0] = m["ProcessorId"].ToString();
                    }
                }

                ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                if (mcHD != null)
                {
                    ManagementObjectCollection mocHD = mcHD.GetInstances();
                    foreach (ManagementObject m in mocHD)
                    {
                        if (m["DeviceID"].ToString() == "C:")
                        {
                            str[1] = m["VolumeSerialNumber"].ToString();
                            break;
                        }
                    }
                }
                return str;
            }
            catch(Exception E)
            {
                //throw new Exception();
                MessageBox.Show(E.Message, "错误1");
                return null;
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s);
        }

        /// <summary>
        /// 读注册表值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetRegistData(string name)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("tsERP", true);
            registData = aimdir.GetValue(name).ToString();
            return registData;
        }

        public static bool IsRegeditExit(string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("tsERP", true);
            if (aimdir == null)
            {
                aimdir = software.CreateSubKey("tsERP");
            }
            subkeyNames = aimdir.GetValueNames();
            foreach (string keyName in subkeyNames)
            {
               
                if (keyName == name)
                {
                    _exit = true;
                    return _exit;
                }
            }
            return _exit;
        } 

        /// <summary>
        /// 写注册表值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tovalue"></param>
        public static void WTRegedit(string name, string tovalue)
        {
            if (IsRegeditExit(name) == false) 
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey("tsERP");
                aimdir.SetValue(name, tovalue);
            }
            else
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("tsERP", true);
                aimdir.SetValue(name, tovalue);
            }
        }





        ///// <summary>
        ///// 根据窗体名加载窗体
        ///// </summary>
        ///// <param name="sClass"></param>
        ///// <param name="sFormName"></param>
        //public static BaseClass.BaseForm LoadForm(string sClass, string sFormName, Form fParent, bool bMdi, object[] parm)
        //{
        //    Assembly _Assembly = Assembly.LoadFile(strPath + sClass);
        //    Type _FormType = _Assembly.GetType(sFormName, true, true);
        //    object _LoadForm = Activator.CreateInstance(_FormType, null);

        //    BaseClass.BaseForm frm = _LoadForm as BaseClass.BaseForm;
        //    frm.SysParm = parm;

        //    if (frm != null)
        //    {
        //        if (bMdi == false)
        //        {
        //            frm.ShowDialog(fParent);
        //            //frm.Dispose();
        //        }
        //        else
        //        {
        //            if (fParent != null)
        //                frm.MdiParent = fParent;
        //            frm.WindowState = FormWindowState.Maximized;
        //            frm.Show();
        //        }

        //    }
        //    return frm;
        //}
    }
}
