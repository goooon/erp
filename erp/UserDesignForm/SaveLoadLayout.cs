using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;

namespace UserDesignForm
{
    class SaveLoadLayout
    {
        public static bool TestFormat(string CurrentForm)
        {
            string SQL = "select F_FormName from t_FormFormat where F_FormName = '" + CurrentForm + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(SQL);
            if (ds.Tables[0].Rows.Count == 0) return false;
            return true;
        }

        public static void SaveToDB(string CurrentForm, MemoryStream s)
        {
            string SQL = "select * from t_FormFormat where F_FormName = '" + CurrentForm + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(SQL);
            DataRow dr = null;
            if (ds.Tables[0].Rows.Count == 0)
            {
                dr = ds.Tables[0].NewRow();
                dr["F_FormName"] = CurrentForm;
                dr["F_Stream"] = s.ToArray();
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                dr = ds.Tables[0].Rows[0];
                dr.BeginEdit();
                dr["F_Stream"] = s.ToArray();
                dr.EndEdit();
            }

            myHelper.SaveData(ds, SQL);
        }

        public static MemoryStream LoadFormDB(string CurrentForm)
        {
            string SQL = "select * from t_FormFormat where F_FormName = '" + CurrentForm + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_Stream"] == DBNull.Value) return null;
                MemoryStream stream = new MemoryStream((byte[])ds.Tables[0].Rows[0]["F_Stream"]);
                return stream;

            }
            return null;
        }

    }
}
