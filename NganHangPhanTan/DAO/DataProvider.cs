using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NganHangPhanTan.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public readonly string DISTRIBUTOR_NAME = "DESKTOP-TU1HSJC";
        private readonly string CONNECTION_STR_TEMPLATE = "Data Source={0};Initial Catalog=NGANHANG;{1}";
        private readonly string REMOTE_LOGIN = "HTKN";
        private readonly string REMOTE_PASS = "123";

        // Giữ khi đăng nhập
        private BindingSource bsSubcribers = new BindingSource();
        private string connectionStr;
        private string serverName;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public string ConnectionStr { get => connectionStr; set => connectionStr = value; }

        private DataProvider()
        {
            SetServerToDistributor();
        }

        public BindingSource GetBSSubcribers()
        {
            if (bsSubcribers.DataSource == null)
            {
                DataTable data = ExecuteDataTable("SELECT * FROM dbo.uv_GetSubcribers");
                bsSubcribers.DataSource = data;
            }
            return bsSubcribers;
        }

        public void SetServerToRemote(string subcriber)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, $"User ID={REMOTE_LOGIN};password={REMOTE_PASS}");
        }

        public void SetServerToSubcriber(string subcriber, string loginName, string pass)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, $"User ID={loginName};password={pass}");
        }

        public void SetServerToDistributor()
        {
            serverName = DISTRIBUTOR_NAME;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, "Integrated Security=True");
        }

        /// <summary>
        /// Test connection to server is running or not.
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionStr);
                connection.Open();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageUtil.ShowErrorMsgDialog($"Lỗi kết nối cơ sở dữ liệu.\nKiểm tra lại username và password.\nChi tiết lỗi: {ex.Message}");
                return false;
            }
            return true;
        }

        public SqlDataReader ExecuteSqlDataReader(string query)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = new SqlConnection(connectionStr),
                CommandText = query,
                CommandType = CommandType.Text
            };

            SqlDataReader sqlDataReader;
            try
            {
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi kết nối cơ sở dữ liệu.\nKiểm tra lại tên đăng nhập và mật khẩu.\nChi tiết lỗi: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Execute query and return result as data table. Return null if connection is closed.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                try
                {
                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    data = null;
                }
            }

            return data;
        }

        /// <summary>
        /// For UPDATE, INSERT, and DELETE statements, the return value is the 
        /// number of rows affected by the command. For all other types of statements, 
        /// the return value is -1.
        /// If no statements are detected that contribute to the count, the return value is -1.
        /// If a rollback occurs, the return value is also -1.
        /// If any error is found, result is -2.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandTimeout = 600, // 10 mins
                };

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    rowsAffected = - 2;
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// For UPDATE, INSERT, and DELETE statements, the return value is the 
        /// number of rows affected by the command. For all other types of statements, 
        /// the return value is -1.
        /// If no statements are detected that contribute to the count, the return value is -1.
        /// If a rollback occurs, the return value is also -1.
        /// If any error is found, result is -2.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string spName, SqlParameter[] parameters)
        {
            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(spName, connection)
                {
                    CommandTimeout = 600, // 10 mins
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    rowsAffected = -2;
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// Execute query and return result at the first column and first row,
        /// null if result set is empty or catching error.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                    data = command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    return null;
                }
            }

            return data;
        }
    }
}
