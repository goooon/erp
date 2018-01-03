namespace CenterLib
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Service  //MarshalByRefObject
    {
        public byte[] BinaryUserSelect(ref string err, string strDB, string strSQL)
        {
            byte[] bArrayResult = null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(this.GetConStr(strDB), CommandType.Text, strSQL);
                ds.RemotingFormat = SerializationFormat.Xml;
                MemoryStream ms = new MemoryStream();
                IFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, ds);
                bArrayResult = ms.ToArray();
                ms.Close();
            }
            catch (Exception ee)
            {
                err = ee.Message.ToString();
            }
            return bArrayResult;
        }

        public string ExecuteSQL(string strDB, string strSQL)
        {
            string str;
            SqlConnection sqlCon = new SqlConnection(this.GetConStr(strDB));
            SqlCommand myCommand = new SqlCommand(strSQL, sqlCon) {
                CommandTimeout = 0
            };
            try
            {
                sqlCon.Open();
                myCommand.ExecuteNonQuery();
                sqlCon.Close();
                str = "";
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            finally
            {
                myCommand.Dispose();
                sqlCon.Dispose();
            }
            return str;
        }

        public DataSet GetAccount(string sFlag)
        {
            string strDB = AppDomain.CurrentDomain.BaseDirectory + "Account.mdb";
            string strOleCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDB;
            DataSet ds = null;
            OleDbConnection oleCon = new OleDbConnection(strOleCon);
            OleDbDataAdapter oleAdt = new OleDbDataAdapter("select * from t_JXCAccount where FVisible = " + sFlag, oleCon);
            ds = new DataSet();
            oleAdt.Fill(ds);
            return ds;
        }

        public byte[] GetCompressDataSet(ref string err, string strDB, string strSQL)
        {
            byte[] bArranyResult = null;
            try
            {
                bArranyResult = DataSetCompression.CompressionDataSet(SqlHelper.ExecuteDataset(this.GetConStr(strDB), CommandType.Text, strSQL));
            }
            catch (Exception ee)
            {
                err = ee.Message.ToString();
            }
            return bArranyResult;
        }

        private string GetConStr(string strDB)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            //string strServer = Api.IniReadValue("Connect", "Server", strPath + "Set.INI");
            //string strLogID = Api.IniReadValue("Connect", "LogID", strPath + "Set.INI");
            //string strLogPass = Api.IniReadValue("Connect", "LogPass", strPath + "Set.INI");


            //string strServer = "EHZQSNIIBCHZXM3\\LMZ";
            //string strLogID = "sa";//Api.IniReadValue("Connect", "LogID", strPath + "Set.INI");
            //string strLogPass = "198296"; //Api.IniReadValue("Connect", "LogPass", strPath + "Set.INI");
            //return ("Data Source=" + strServer + ";Initial Catalog=" + strDB + ";Persist Security Info=True;User ID=" + strLogID + ";Password=" + strLogPass);
            return System.Configuration.ConfigurationManager.AppSettings["Connection"].ToString();
        }

        public byte[] GetDocument(string DocumentName)
        {
            FileStream objfilestream = new FileStream(@"C:\DocumentDirectory\" + DocumentName, FileMode.Open, FileAccess.Read);
            int len = (int) objfilestream.Length;
            byte[] documentcontents = new byte[len];
            objfilestream.Read(documentcontents, 0, len);
            objfilestream.Close();
            return documentcontents;
        }

        public int GetDocumentLen(string DocumentName)
        {
            FileStream objfilestream = new FileStream(@"C:\DocumentDirectory\" + DocumentName, FileMode.Open, FileAccess.Read);
            int len = (int) objfilestream.Length;
            objfilestream.Close();
            return len;
        }

        public DataSet GetDs(string strDB, string strSQL)
        {
            return SqlHelper.ExecuteDataset(this.GetConStr(strDB), CommandType.Text, strSQL);
        }

        public Hashtable GetIniInfo()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            string strServer = Api.IniReadValue("Connect", "Server", strPath + "Set.INI");
            string strLogID = Api.IniReadValue("Connect", "LogID", strPath + "Set.INI");
            string strLogPass = Api.IniReadValue("Connect", "LogPass", strPath + "Set.INI");
            Hashtable ht = new Hashtable();
            ht.Add("Server", strServer);
            ht.Add("LogID", strLogID);
            ht.Add("Pass", strLogPass);
            return ht;
        }

        public byte[] GetOtherByte(ref string err, string strDB, string strSQL, Hashtable htParm)
        {
            byte[] bArranyResult = null;
            try
            {
                SqlParameter[] sqlParm = new SqlParameter[htParm.Count];
                int i = 0;
                foreach (DictionaryEntry de in htParm)
                {
                    sqlParm[i] = new SqlParameter(de.Key.ToString(), de.Value);
                    i++;
                }
                bArranyResult = DataSetCompression.CompressionDataSet(SqlHelper.ExecuteDataset(this.GetConStr(strDB), CommandType.Text, strSQL, sqlParm));
            }
            catch (Exception ee)
            {
                err = ee.Message.ToString();
            }
            return bArranyResult;
        }

        public string Login(string userName, string password)
        {
            if ((userName == "YGA") && (password == "Kinger"))
            {
                return "success";
            }
            return "failed";
        }

        public string SaveData(string strDB, DataSet ds, string strSQL)
        {
            try
            {
                SqlConnection con = new SqlConnection(this.GetConStr(strDB));
                SqlDataAdapter myAdt = new SqlDataAdapter(strSQL, con);
                SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
                myAdt.Update(ds);
                con.Dispose();
                myAdt.Dispose();
                bd.Dispose();
                return "";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0xa43)
                {
                    return "数据重复，请检查!!";
                }
                return ("错误码:" + ex.Number.ToString() + " 错误信息:" + ex.Message);
            }
        }

        public bool SaveDocument(byte[] docbinaryarray, string docname)
        {
            FileStream objfilestream = new FileStream(@"C:\DocumentDirectory\" + docname, FileMode.Create, FileAccess.ReadWrite);
            objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
            objfilestream.Close();
            return true;
        }

        public string SaveMuteData(string strDB, DataSet[] ds, string[] strSQL)
        {
            string str;
            SqlConnection con = new SqlConnection(this.GetConStr(strDB));
            int intCnt = ds.Length;
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                for (int i = 0; i < intCnt; i++)
                {
                    SqlCommand myComm = new SqlCommand {
                        Connection = con,
                        Transaction = tran,
                        CommandText = strSQL[i],
                        CommandTimeout = 0
                    };
                    SqlDataAdapter myAdt = new SqlDataAdapter {
                        SelectCommand = myComm
                    };
                    SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
                    myAdt.Update(ds[i]);
                }
                tran.Commit();
                str = "";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                str = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return str;
        }

        public string SaveMuteData1(string strDB, DataSet[] ds, string[] strSQL, Hashtable htParm)
        {
            string  str;
            SqlParameter[] sqlParm = new SqlParameter[htParm.Count];
            int j = 0;
            foreach (DictionaryEntry de in htParm)
            {
                sqlParm[j] = new SqlParameter(de.Key.ToString(), de.Value);
                j++;
            }
            SqlConnection con = new SqlConnection(this.GetConStr(strDB));
            int intCnt = ds.Length;
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                for (int i = 0; i < intCnt; i++)
                {
                    SqlCommand myComm = new SqlCommand {
                        Connection = con,
                        Transaction = tran,
                        CommandText = strSQL[i]
                    };
                    myComm.Parameters.Add(sqlParm[0].ParameterName, sqlParm[0].Value);
                    myComm.CommandTimeout = 0;
                    SqlDataAdapter myAdt = new SqlDataAdapter {
                        SelectCommand = myComm
                    };
                    SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
                    myAdt.Update(ds[i]);
                    myComm.Dispose();
                }
                tran.Commit();
                str = "";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                str = ex.Message;
            }
            finally
            {
                tran.Dispose();
            }
            return str;
        }
    }
}

