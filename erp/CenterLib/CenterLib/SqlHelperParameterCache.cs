namespace CenterLib
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;

    public  class SqlHelperParameterCache
    {
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        private SqlHelperParameterCache()
        {
        }

        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            string hashKey = connectionString + ":" + commandText;
            paramCache[hashKey] = commandParameters;
        }

        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            int i = 0;
            int j = originalParameters.Length;
            while (i < j)
            {
                clonedParameters[i] = (SqlParameter) ((ICloneable) originalParameters[i]).Clone();
                i++;
            }
            return clonedParameters;
        }

        private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            SqlParameter[] sqlpara;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spName, cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmd);
                    if (!includeReturnValueParameter)
                    {
                        cmd.Parameters.RemoveAt(0);
                    }
                    SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                    cmd.Parameters.CopyTo(discoveredParameters, 0);
                    sqlpara = discoveredParameters;
                }
            }
            return sqlpara;
        }

        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = connectionString + ":" + commandText;
            SqlParameter[] cachedParameters = (SqlParameter[]) paramCache[hashKey];
            if (cachedParameters == null)
            {
                return null;
            }
            return CloneParameters(cachedParameters);
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            SqlParameter[] cachedParameters = (SqlParameter[]) paramCache[hashKey];
            if (cachedParameters == null)
            {
                object obj;
                paramCache[hashKey] = obj = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter);
                cachedParameters = (SqlParameter[]) obj;
            }
            return CloneParameters(cachedParameters);
        }
    }
}

