using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using LinesVisualization.Classes.Data;

namespace LinesVisualization.Classes.Services
{
    public class DatabaseRepository
    {
        private string serverConnStr = "Data Source=.;Integrated security=True";

        public string DatabaseName { get; private set; }

        private Dictionary<string, string[]> tableHeaders;

        private SqlConnection serverConnection;
        private SqlConnection dbConnection;

        public DatabaseRepository(string dbName)
        {
            DatabaseName = dbName;
            string connStr = $"Data Source=.;Initial Catalog={dbName};Integrated security=True";

            tableHeaders = new Dictionary<string, string[]>();
            serverConnection = new SqlConnection(serverConnStr);
            dbConnection = new SqlConnection(connStr);
        }

        public void CreateDatabase()
        {
            string queryCreateDB = $"Create database {DatabaseName}";

            SqlCommand createDBCommand;

            try
            {
                if (!IsDatabaseExist())
                {
                    serverConnection.Open();

                    createDBCommand = serverConnection.CreateCommand();
                    createDBCommand.CommandText = queryCreateDB;
                    createDBCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                serverConnection?.Close();
            }
        }

        public void CreateTable(string tableName, NodeObjectsList nodes)
        {
            string queryCreateTable;
            SqlCommand createTableCommand;

            try
            {
                if (!IsTableExist(tableName))
                {
                    string[] columnNames = new string[nodes.ColumnNames.Length];
                    Array.Copy(nodes.ColumnNames, columnNames, nodes.ColumnNames.Length);
                    tableHeaders.Add(tableName, columnNames);

                    queryCreateTable = GetCreateTableQuery(tableName, columnNames);
                    dbConnection.Open();

                    createTableCommand = dbConnection.CreateCommand();
                    createTableCommand.CommandText = queryCreateTable;
                    createTableCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        public void DropTable(string tableName)
        {
            string queryDropTable = $"DROP TABLE {tableName}";
            SqlCommand dropTableCommand;

            try
            {
                if (IsTableExist(tableName))
                {
                    dbConnection.Open();

                    dropTableCommand = dbConnection.CreateCommand();
                    dropTableCommand.CommandText = queryDropTable;
                    dropTableCommand.ExecuteNonQuery();

                    tableHeaders.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        public void InsertDataIntoTable(string tableName, NodeObjectsList nodes)
        {
            if (!tableHeaders.ContainsKey(tableName))
                throw new Exception("There is no such table");

            string queryInsertData;
            SqlCommand insertDataCommand;

            try
            {
                string[] columnNames = tableHeaders.GetValueOrDefault(tableName);

                queryInsertData = GetInsertDataQuery(tableName, columnNames);
                dbConnection.Open();

                insertDataCommand = dbConnection.CreateCommand();
                insertDataCommand.CommandText = queryInsertData;

                for (int i = 0; i < columnNames.Length; ++i)
                {
                    insertDataCommand.Parameters.Add($"@{columnNames[i]}", SqlDbType.NVarChar, 50);
                }

                NodeObject currentObject;
                string temp = string.Empty;

                for (int i = 0; i < nodes.NodeObjects.Count; ++i)
                {
                    currentObject = nodes.NodeObjects[i];

                    for (int j = 0; j < nodes.ColumnNames.Length; ++j)
                    {
                        temp = currentObject[nodes.ColumnNames[j]];

                        insertDataCommand.Parameters[j].Value = temp;
                    }

                    insertDataCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        public DataSet GetAllTableData(string tableName)
        {
            string getAllData = $"SELECT * FROM {tableName}";

            SqlDataAdapter getAllDataAdapter;
            DataSet dataSet = null;

            try
            {
                dbConnection.Open();
                getAllDataAdapter = new SqlDataAdapter(getAllData, dbConnection);

                dataSet = new DataSet();
                getAllDataAdapter.Fill(dataSet, tableName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }

            return dataSet;
        }

        public string[] GetTableColumnNames(string tableName)
        {
            string[] columnNames = null;

            try
            {
                dbConnection.Open();

                DataTable dataTable = dbConnection
                    .GetSchema("Columns", new string[]
                    {
                        null,
                        null,
                        tableName
                    });

                columnNames = (from row in dataTable.AsEnumerable()
                               select row.Field<string>("COLUMN_NAME"))
                               .ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }

            return columnNames;
        }

        public bool IsDatabaseExist()
        {
            bool isDatabaseExist = false;
            string query = $"SELECT db_id('{DatabaseName}')";

            SqlCommand command;

            try
            {
                serverConnection.Open();

                command = serverConnection.CreateCommand();
                command.CommandText = query;

                isDatabaseExist = command.ExecuteScalar() != DBNull.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                serverConnection?.Close();
            }

            return isDatabaseExist;
        }

        public bool IsTableExist(string tableName)
        {
            bool isTableExist = false;

            DataTable dTable;

            try
            {
                dbConnection.Open();

                dTable = dbConnection
                    .GetSchema("TABLES", new string[]
                    {
                        null,
                        null,
                        tableName
                    });

                isTableExist = dTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }

            return isTableExist;
        }

        private string GetCreateTableQuery(string tableName, string[] columnNames)
        {
            if (columnNames == null || columnNames.Length == 0)
                throw new Exception("No headers to create the table");

            string query = $"Create table {tableName}(id int not null primary key identity(1,1)";

            TransformSeporatorsIntoUnderscores(in columnNames);

            foreach (string columnName in columnNames)
            {
                query += $",[{columnName}] nvarchar(50)";
            }

            query += ")";

            return query;
        }

        private string GetInsertDataQuery(string tableName, string[] columnNames)
        {
            string queryInsertData = $"INSERT INTO {tableName}(";
            string valuesStr = $"VALUES (";

            for (int i = 0; i < columnNames.Length; ++i)
            {
                queryInsertData += $"{columnNames[i]}";
                valuesStr += $"@{columnNames[i]}";

                queryInsertData += i != columnNames.Length - 1 ? ", " : ")";
                valuesStr += i != columnNames.Length - 1 ? ", " : ")";
            }

            queryInsertData += valuesStr;

            return queryInsertData;
        }

        private void TransformSeporatorsIntoUnderscores(in string[] strings)
        {
            string separators = "[ ,;]";

            for (int i = 0; i < strings.Length; ++i)
            {
                strings[i] = Regex.Replace(strings[i], separators, "_");
            }
        }
    }
}
