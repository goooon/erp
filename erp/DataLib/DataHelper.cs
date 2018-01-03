using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Runtime.Remoting;
//using System.Runtime.Remoting.Channels;
//using System.Runtime.Remoting.Channels.Tcp;
namespace DataLib
{
    public class DataHelper
    {
        /// <summary>
        /// Remoting呼叫中间层
        /// </summary>
        /// <returns></returns>
        //private CenterLib.Service GetObj()
        //{
        //    try
        //    {
        //        ChannelServices.RegisterChannel(new TcpClientChannel(),false);
        //        CenterLib.Service obj = (CenterLib.Service)Activator.GetObject(typeof(CenterLib.Service), "tcp://" + SysVar.strServer + ":8082/tskj");
        //        if (obj == null)
        //        {
        //            MessageBox.Show("中间层呼叫失败！！");
        //            return null;
        //        }
        //        return obj;
        //    }
        //    finally
        //    {
        //        IChannel chanel = ChannelServices.GetChannel("tcp");
        //        ChannelServices.UnregisterChannel(chanel);
        //    }
        //}



        private CenterLib.Service GetObj()
        {
            try
            {

                CenterLib.Service obj = new CenterLib.Service();//(CenterLib.Service)Activator.GetObject(typeof(CenterLib.Service), "tcp://" + SysVar.strServer + ":8082/tskj");
                //if (obj == null)
                //{
                //    MessageBox.Show("中间层呼叫失败！！");
                //    return null;
                //}
                return obj;
            }
            finally
            {
                //IChannel chanel = ChannelServices.GetChannel("tcp");
                //ChannelServices.UnregisterChannel(chanel);
            }
        }


        /// <summary>
        /// 设置打印连接参数
        /// </summary>
        public void SetPrintInfo()
        {
            CenterLib.Service obj = GetObj();
            Hashtable ht = obj.GetIniInfo();

            int intCnt = ht.Count;

            foreach (DictionaryEntry de in ht)
            {
                //if (de.Key.ToString() == "Server")
                //    DataLib.SysVar.strServer = de.Value.ToString();

                if (de.Key.ToString() == "LogID")
                    DataLib.SysVar.strLogID = de.Value.ToString();

                if (de.Key.ToString() == "Pass")
                    DataLib.SysVar.strLogPsw = de.Value.ToString();
            }

        }

        /// <summary>
        /// WebService取得相应服务
        /// </summary>
        /// <returns></returns>
        private JxcService.Service GetService()
        {
            JxcService.Service myService = new JxcService.Service();
            myService.Url = SysVar.strUrl;
            return myService;
        }

        /// <summary>
        /// 取得后台设置的帐套
        /// </summary>
        /// <returns></returns>
        public DataSet GetAccount(string sFlag)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                return myService.GetAccount();
            }
            else
            {
                CenterLib.Service obj = GetObj();
                DataSet ds1=obj.GetAccount(sFlag);


                return ds1;


            }
        }

        /// <summary>
        /// 从中间层(webservice)取连接数据库字符串
        /// </summary>
        /// <returns></returns>
        public string GetCon()
        {
            JxcService.Service myService = GetService();
            return myService.GetConStr(DataLib.SysVar.strDB);
        }

        /// <summary>
        /// 测试是否登录成功
        /// </summary>
        /// <param name="strServer"></param>
        /// <returns></returns>
        public bool TestLogin(string strServer)
        {
            SysVar.strServer = strServer;
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                if (myService.Login("YGA", "Kinger") == "success")
                    return true;
                else
                    return false;
            }
            else
            {
                CenterLib.Service obj = GetObj();

                if (obj.Login("YGA", "Kinger") == "success")
                    return true;
                else
                    return false;
                /*

                try
                {
                    if (obj.Login("YGA", "Kinger") == "success")
                        return true;
                    else
                        return false;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "错误");
                    return false;
                }
                 */ 
            }
        }

        /// <summary>
        /// 根据传过去的SQL语句得到相应数据集
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataSet GetDs(string strSQL)
        {
            string err = "";
            DataSet ds = null;
            byte[] bUserData = null;
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                bUserData = myService.GetCompressDataSet(ref err, SysVar.strDB, strSQL);
                if (err != "")
                {
                    MessageBox.Show(err, "错误");
                    err = "";
                    return null;
                }
                ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
            else
            {
                CenterLib.Service obj = GetObj();

                bUserData = obj.GetCompressDataSet(ref err, SysVar.strDB, strSQL);
                if (err != "")
                {
                    MessageBox.Show(err, "错误");
                    err = "";
                    return null;
                }
                ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
        }

        /// <summary>
        /// 根据数据集及SQL语句保存数据
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public int SaveData(DataSet ds, string strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();

                string strErr = myService.SaveData(SysVar.strDB, ds, strSQL);

                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return -1;
                }
                return 0;
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return -1;
                }
                return 0;
            }
        }

        /// <summary>
        /// 带参数SQL,并返回结果数据集
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public DataSet GetOtherDs(string strSQL, Hashtable parm)
        {
            string err = "";
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();

                byte[] bytes = DataSetCompression.SerializeData(parm);

                byte[] bUserData = myService.GetOtherByte(ref err, SysVar.strDB, strSQL, bytes);
                if (err != "")
                {
                    MessageBox.Show(err, "错误");
                    err = "";
                    return null;
                }
                DataSet ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
            else
            {
                CenterLib.Service obj = GetObj();
                byte[] bUserData = obj.GetOtherByte(ref err, SysVar.strDB, strSQL, parm);
                if (err != "")
                {
                    MessageBox.Show(err, "错误");
                    err = "";
                    return null;
                }
                DataSet ds = DataSetCompression.DecompressionDataSet(bUserData);
                return ds;
            }
        }

        /// <summary>
        /// 多数据集保存,传递数据集数组及SQL语句数组
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public string SaveMuteData(DataSet[] ds, string[] strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                string strErr = myService.SaveMuteData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return strErr;
                }
                return "";
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveMuteData(SysVar.strDB, ds, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return strErr;
                }
                return "";
            }
        }

        /// <summary>
        /// 多数据集保存(带参数)
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public string SaveMuteData1(DataSet[] ds, string[] strSQL, Hashtable parm)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                byte[] bytes = DataSetCompression.SerializeData(parm);
                string strErr = myService.SaveMuteData1(SysVar.strDB, ds, strSQL, bytes);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return strErr;
                }
                return "";
            }
            else
            {
                CenterLib.Service obj = GetObj();

                string strErr = obj.SaveMuteData1(SysVar.strDB, ds, strSQL, parm);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return strErr;
                }
                return ""; 
            }

        }

        /// <summary>
        /// 执行无返回值ＳＱＬ语句
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public int ExecuteSQL(string strSQL)
        {
            if (DataLib.SysVar.intConnect == 0)
            {
                JxcService.Service myService = GetService();
                string strErr = myService.ExecuteSQL(SysVar.strDB, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return -1;
                }
                return 0;
            }
            else
            {
                CenterLib.Service obj = GetObj();
                string strErr = obj.ExecuteSQL(SysVar.strDB, strSQL);
                if (strErr.Length > 0)
                {
                    MessageBox.Show(strErr, "错误");
                    return -1;
                }
                return 0;
            }
        }
    }
}
