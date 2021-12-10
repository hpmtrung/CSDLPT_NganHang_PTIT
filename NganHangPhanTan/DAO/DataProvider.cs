using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan.DAO
{
    class DataProvider
    {
        private static DataProvider uniqueInstance;

        public readonly string DISTRIBUTOR_NAME = "DESKTOP-TU1HSJC";
        private readonly string CONNECTION_STR_TEMPLATE = "Data Source={0};Initial Catalog=NGANHANG;{1}";
        private readonly string REMOTE_LOGIN = "HTKN";
        private readonly string REMOTE_PASS = "123";

        // Giữ khi đăng nhập
        private BindingSource bsSubcribers = new BindingSource();

        private string connectionStr;
        private string serverName;

        public static DataProvider UniqueInstance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new DataProvider();
                return uniqueInstance;
            }
            private set
            {
                uniqueInstance = value;
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
                String query = "SELECT * FROM dbo.uv_GetSubcribers";
                DataTable data = ExecuteQueryDataTable(query);
                bsSubcribers.DataSource = data;
            }
            return bsSubcribers;
        }

        private bool OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n{ex.Message}", "", MessageBoxButtons.OK);
                return false;
            }

            return true;
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
        public bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Execute query and return result as data table. Return null if connection is closed.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                if (!OpenConnection(connection))
                {
                    return null;
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparam)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);
            }

            return data;
        }

        /// <summary>
        /// For UPDATE, INSERT, and DELETE statements, the return value is the number of rows affected by the command. 
        /// For all other types of statements or catching error, the return value is -1.
        /// Return 0 if having any errors.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                if (!OpenConnection(connection))
                {
                    return -1;
                }

                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandTimeout = 600, // 10 mins
                };

                if (parameters != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparam)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    int rowNum = command.ExecuteNonQuery();
                    return rowNum;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
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
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                if (!OpenConnection(connection))
                {
                    return null;
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listparam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listparam)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    object data = command.ExecuteScalar();
                    return data;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
