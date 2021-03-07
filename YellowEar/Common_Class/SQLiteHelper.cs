using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace YellowEar
{
    /// <summary>
    /// sqlite 数据库帮助类，内部均为静态数据，必须先赋值连接字符串才能使用
    /// </summary>
    public class SqliteHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string _dbConStr;// = "Data Source = "+Environment.CurrentDirectory+@"\db.sqlite;Version=3";
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DbConStr
        {
            get { return _dbConStr; }
            set 
            { 
                _dbConStr = "Data Source = " + Environment.CurrentDirectory+ @"\"+value+ ";Version=3"; 
            }
        }
        /// <summary>
        /// 创建SQLite数据库参数对象
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="paramType">参数类型</param>
        /// <param name="paramValue">参数值</param>
        /// <returns></returns>
        private SQLiteParameter CreateParameter(string paramName, DbType paramType, object paramValue)
        {
            var param = new SQLiteParameter();
            param.DbType = paramType;
            param.ParameterName = paramName;
            param.Value = paramValue;
            return param;
        }
        /// <summary>
        /// 通过给定带参数的查询字符串和相应的参数值数组，生成SQLiteParameter类型的数组
        /// </summary>
        /// <param name="sqlText">带参数的查询字符串</param>
        /// <param name="sqlParams">参数值数组</param>
        /// <returns></returns>
        private SQLiteParameter[] ConvertToSqliteParameters(string sqlText, object[] sqlParams)
        {
            var paramList = new List<SQLiteParameter>();
            string parmString = sqlText.Substring(sqlText.IndexOf("@", System.StringComparison.Ordinal));
            parmString = parmString.Replace(",", " ,");
            //匹配sql语句中定义的参数
            string pattern = @"(@)\S*(.*?)\b";
            Regex ex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = ex.Matches(parmString);
            string[] paramNames = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                paramNames[i] = m.Value;
                i++;
            }

            // now let's type the parameters  
            int j = 0;
            foreach (object o in sqlParams)
            {
                string type = (o == null) ? typeof(Nullable).ToString() : o.GetType().ToString();
                //SQLiteParameter parm = new SQLiteParameter();
                switch (type)
                {
                    case ("DBNull"):
                    case ("Char"):
                    case ("SByte"):
                    case ("UInt16"):
                    case ("UInt32"):
                    case ("UInt64"):
                        throw new SystemException("Invalid data type");
                    case ("System.Nullable"):
                        //parm.DbType = DbType.String;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (string)sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.String, (string)sqlParams[j]));
                        break;
                    case ("System.String"):
                        //parm.DbType = DbType.String;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (string)sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.String, (string)sqlParams[j]));
                        break;
                    case ("System.Byte[]"):
                        //parm.DbType = DbType.Binary;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (byte[])sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.Binary, (byte[])sqlParams[j]));
                        break;
                    case ("System.Int32"):
                        //parm.DbType = DbType.Int32;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (int)sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.Int32, (int)sqlParams[j]));
                        break;
                    case ("System.Boolean"):
                        //parm.DbType = DbType.Boolean;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (bool)sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.Boolean, (bool)sqlParams[j]));
                        break;
                    case ("System.DateTime"):
                        //parm.DbType = DbType.DateTime;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = Convert.ToDateTime(sqlParams[j]);
                        paramList.Add(CreateParameter(paramNames[j], DbType.DateTime, Convert.ToDateTime(sqlParams[j])));
                        break;
                    case ("System.Double"):
                        //parm.DbType = DbType.Double;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = Convert.ToDouble(sqlParams[j]);
                        paramList.Add(CreateParameter(paramNames[j], DbType.Double, Convert.ToDouble(sqlParams[j])));
                        break;
                    case ("System.Decimal"):
                        //parm.DbType = DbType.Decimal;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = Convert.ToDecimal(sqlParams[j]);
                        paramList.Add(CreateParameter(paramNames[j], DbType.Decimal, Convert.ToDecimal(sqlParams[j])));
                        break;
                    case ("System.Guid"):
                        //parm.DbType = DbType.Guid;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = (System.Guid)(sqlParams[j]);
                        paramList.Add(CreateParameter(paramNames[j], DbType.Guid, (Guid)sqlParams[j]));
                        break;
                    case ("System.Object"):
                        //parm.DbType = DbType.Object;
                        //parm.ParameterName = paramNames[j];
                        //parm.Value = sqlParams[j];
                        paramList.Add(CreateParameter(paramNames[j], DbType.Object, sqlParams[j]));
                        break;
                    default:
                        throw new SystemException("Value is of unknown data type");
                } // end switch
                j++;
            }
            return paramList.ToArray();
        }

        /// <summary>
        /// 创建操作命令
        /// </summary>
        /// <param name="conn">数据库连接字符串</param>
        /// <param name="sqlText">带参数的查询字符串</param>
        /// <param name="sqlParams">参数值数组</param>
        /// <returns></returns>
        private SQLiteCommand CreateCommand(SQLiteConnection conn, string sqlText, object[] sqlParams)
        {
            var command = new SQLiteCommand(sqlText, conn);
            command.CommandType = CommandType.Text;
            if (sqlParams != null && sqlParams.Length > 0)
            {
                var sqliteParams = ConvertToSqliteParameters(sqlText, sqlParams);
                command.Parameters.AddRange(sqliteParams);
            }
            return command;
        }
        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbName">数据名</param>
        /// <returns></returns>
        public void CreateDb(string dbName)
        {
            try
            {
                SQLiteConnection.CreateFile(dbName);
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.CreateDb()。" + e.Message);
            }
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="definition">表的定义,即列名数组</param>
        /// <returns></returns>
        public void CreateTable(string tableName, string[] definition)
        {
            try
            {
                string values = string.Join(", ", definition);
                string sql = string.Format("create table {0}({1});", tableName, values);
                ExecuteNonQuery(sql, null);
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.CreateTable()。" + e.Message);
            }
        }
        /// <summary>
        /// 清空表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public void ClearTable(string tableName)
        {
            try
            {
                string sql = string.Format("delete from {0};", tableName);
                ExecuteNonQuery(sql, null);
            }
            catch(Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.ClearTable()。" + e.Message);
            }
        }
        /// <summary>
        /// 清空数据库
        /// </summary>
        /// <returns></returns>
        public void ClearDb()
        {
            try
            {
                string sql = "select NAME from SQLITE_MASTER where type='table' order by NAME;";
                DataTable tables = ExecuteDataTable(sql, null);
                foreach (DataRow table in tables.Rows)
                {
                    ClearTable(table["NAME"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.ClearDb()。" + e.Message);
            }
        }
        /// <summary>
        /// 获取所有数据库表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSchema()
        {
            using (var connection = new SQLiteConnection(_dbConStr))//使用using块可以不用手动关闭连接对象
            {
                connection.Open();
                DataTable dt = connection.GetSchema("TABLES");
                return dt;
            }
        }

        /// <summary>
        /// 执行select查询语句，返回IDataReader实例,IDataReader实例使用完后必须手动关闭
        /// DataReader对象会持续连接数据库，并且以顺序的方式每次只读一条数据，通过DataReader.read方法读取下一条数据
        /// 这期间conn对象会一直被DataReader对象占用，直到调用DataReader.close方法
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="sqlParams">查询语句所需要的参数</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, object[] sqlParams)
        {
            using (var connection = new SQLiteConnection(_dbConStr))
            {
                connection.Open();

                SQLiteCommand command = CreateCommand(connection, sql, sqlParams);
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 执行select查询语句，返回包含查询结果的datatable
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="sqlParams">查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, object[] sqlParams)
        {
            using (var connection = new SQLiteConnection(_dbConStr))
            {
                connection.Open();

                SQLiteCommand command = CreateCommand(connection, sql, sqlParams);
                SQLiteDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);//这个方法可以把DataReader中的数据全部写到DataTable中去，避免了DataReader每次只读一条
                reader.Close();
                return dt;
                //用下面的这种方法，会有一个异常
                //SqliteDataAdapter adapter = new SqliteDataAdapter(command);                
                //adapter.Fill(dt);
            }
        }

        /// <summary>
        /// 执行select查询语句，返回查询结果的第一行第一列,如果查询结束为空，则返回空字符串
        /// </summary>
        /// <param name="sql">select查询语句,其它语句无用</param>
        /// <param name="sqlParams">查询语句所需要的参数</param>
        /// <returns></returns>
        public string ExecuteScalar(string sql, object[] sqlParams)
        {
            using (var connection = new SQLiteConnection(_dbConStr))
            {
                connection.Open();

                SQLiteCommand command = CreateCommand(connection, sql, sqlParams);
                object value = command.ExecuteScalar();
                return value != null ? value.ToString() : "";
            }
        }

        /// <summary>
        /// 执行语句，返回受影响的行数
        /// </summary>
        /// <param name="sql">语句</param>
        /// <param name="sqlParams">语句所需要的参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, object[] sqlParams)
        {
            int affectedRows = 0;
            using (var connection = new SQLiteConnection(_dbConStr))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())//开始一个事务
                {
                    SQLiteCommand command = CreateCommand(connection, sql, sqlParams);
                    affectedRows = command.ExecuteNonQuery();
                    transaction.Commit();//提交一个事务
                }
            }
            return affectedRows;
        }


        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="data">需要更新的键值对（列名，列值）</param>
        /// <param name="where">判断表达式</param>
        /// <returns></returns>
        public void Update(string tableName, Dictionary<string, object> data, KeyValuePair<string, object> where)
        {
            var columnsList = data.Keys;
            var valuesList = data.Values.ToList();
            string columnsStr = string.Join(", ", (from column in columnsList select column + "=@" + column));

            string whereStr = string.Format(" {0}=@{1} ", where.Key, where.Key);
            valuesList.Add(where.Value);
            try
            {
                string sql = string.Format("update {0} set {1} where {2};", tableName, columnsStr, whereStr);
                ExecuteNonQuery(sql, valuesList.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.Update()。" + e.Message);
            }
        }
        /// <summary>
        /// 删除表项操作
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="where">判断表达式</param>
        /// <returns></returns>
        public void Delete(string tableName, KeyValuePair<string, object> where)
        {
            string whereStr = string.Format(" {0}=@{1} ", where.Key, where.Key);
            try
            {
                string sql = string.Format("delete from {0} where {1};", tableName, whereStr);
                ExecuteNonQuery(sql, new object[] { where.Value });
            }
            catch (Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.Delete()。" + e.Message);
            }
        }
        /// <summary>
        /// 插入表项操作
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="data">需要插入的键值对（列名，列值）</param>
        /// <returns></returns>
        public void Insert(string tableName, Dictionary<string, object> data)
        {
            var columnsList = data.Keys;
            var valuesList = data.Values;
            string columnsStr = string.Join(", ", columnsList);
            string paramsStr = string.Join(", ", (from column in columnsList select "@" + column));
            try
            {
                string sql = string.Format("insert into {0}({1}) values({2});", tableName, columnsStr, paramsStr);
                ExecuteNonQuery(sql, valuesList.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("错误位置：SqliteHelper.Insert()。" + e.Message);
            }
        }
        /// <summary>
        /// 初始化本程序需要的各类表
        /// </summary>
        public void InitialTables()
        {
           
        }
    }
}