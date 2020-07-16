using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Databasetools
{
    
    class SqlUtils
    {
        public string dbname { get; set; }

        public string sql { get; set; }

        public static SqlConnection GetConnection(string dbname)
        {
            SqlConnection conn = new SqlConnection("server=.;uid=kenny;password=kenny1975;database=" + dbname);
            return conn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType">1表示sql语句，2表示存储过程</param>
        /// <param name="pras"></param>
        /// <returns></returns>
        public static int ExecuteNoneQuery(string sql,int cmdType,string dbname,params SqlParameter[] pras)
        {
            int num = 0;
            //创建SqlCommand对象
            SqlConnection conn = GetConnection(dbname);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn );
            
            if (cmdType == 2)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (pras != null && pras.Length>0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(pras);
            }
            num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();
            return num;
        }  

        public static object ExecuteScalar(string sql, int cmdType, string dbname, params SqlParameter[] pras)
        {
           object num = null;
            //创建SqlCommand对象
            SqlConnection conn = GetConnection(dbname);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (cmdType == 2)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (pras != null && pras.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(pras);
            }
            num = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            conn.Close();
            return num;
        }

        public static SqlDataReader ExecutReader(string sql, int cmdType, string dbname, params SqlParameter[] pras)
        {
            SqlConnection conn = GetConnection(dbname);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = null;
            if (cmdType == 2)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (pras != null && pras.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(pras);
            }
            try
            {
                dr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (Exception e)
            {

                conn.Close();
                throw new Exception("数据执行异常",e);
            }
            
            return dr;
        }

        public static DataTable GetDataTable(string sql, int cmdType, string dbname, params SqlParameter[] pras)
        {
            SqlConnection conn = GetConnection(dbname);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (cmdType == 2)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (pras != null && pras.Length > 0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(pras);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
                conn.Open();
                sda.Fill(dt);
                conn.Close();
                cmd.Parameters.Clear();
            
             
            return dt;
        }
        public static bool BatchExecuteNoneQuery(string dbname,List<string> sqls)
        {
            using(SqlConnection conn = GetConnection(dbname))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = tran;
                try
                {
                    for (int i = 0; i < sqls.Count; i++)
                    {
                        cmd.CommandText = sqls[i];
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception("执行事务异常",e);
                }
                finally
                {
                    tran.Dispose();
                    cmd.Dispose();
                    conn.Close();
                }

            }
        }
    }
}
