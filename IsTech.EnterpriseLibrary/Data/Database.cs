using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Text;
using IsTech.EnterpriseLibrary.Properties;

namespace IsTech.EnterpriseLibrary.Data
{
    public class Database
    {
        private string _connectString;
        private DbProviderFactory _dbProviderFactory;

        public string ConnectString
        {
            get
            {
                return this._connectString;
            }
        }

        public DbProviderFactory DbProviderFactory
        {
            get { return this._dbProviderFactory; }
        }   
        public Database(string connectionString, DbProviderFactory dbProviderFactory)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException(Resources.ExceptionNullOrEmptyString, "connectionString");
            if (dbProviderFactory == null) throw new ArgumentNullException("dbProviderFactory");

            this._connectString = connectionString;
            this._dbProviderFactory = dbProviderFactory;            
        }

        public DbConnection CreateConnection()
        {
            DbConnection connectinon = this._dbProviderFactory.CreateConnection();
            connectinon.ConnectionString = this._connectString;
            return connectinon;
        }

        public DataSet ExecuteDataSet(DbCommand command)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            command.CommandTimeout = 3000;            
            LoadDataSet(command, dataSet, "Table");
            return dataSet;
        }

        public DataSet ExecuteDataSet(DbCommand command, DbTransaction trans)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            command.CommandTimeout = 3000;
            command.Transaction = trans;
            LoadDataSet(command, dataSet, "Table");
            return dataSet;
        }

        public object ExecuteScalar(DbCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    PrepareCommand(command, connection);
                    return DoExecuteScalar(command);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// <para>Executes the <paramref name="command"/> within a <paramref name="transaction" />, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</para>
        /// </summary>
        /// <param name="command">
        /// <para>The command that contains the query to execute.</para>
        /// </param>
        /// <param name="transaction">
        /// <para>The <see cref="IDbTransaction"/> to execute the command within.</para>
        /// </param>
        /// <returns>
        /// <para>The first column of the first row in the result set.</para>
        /// </returns>
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        public virtual object ExecuteScalar(DbCommand command, DbTransaction transaction)
        {
            if (command == null) throw new ArgumentNullException("command");

            PrepareCommand(command, transaction);
            return DoExecuteScalar(command);
        }

        /// <summary>
        /// <para>Executes the <paramref name="command"/> and returns the number of rows affected.</para>
        /// </summary>
        /// <param name="command">
        /// <para>The command that contains the query to execute.</para>
        /// </param>       
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        public int ExecuteNonQuery(DbCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");
            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    PrepareCommand(command, connection);
                    return DoExecuteNonQuery(command);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// <para>Executes the <paramref name="command"/> within the given <paramref name="transaction" />, and returns the number of rows affected.</para>
        /// </summary>
        /// <param name="command">
        /// <para>The command that contains the query to execute.</para>
        /// </param>
        /// <param name="transaction">
        /// <para>The <see cref="IDbTransaction"/> to execute the command within.</para>
        /// </param>
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        public int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            PrepareCommand(command, transaction);
            return DoExecuteNonQuery(command);
        }

        /// <summary>
        /// <para>Executes the <paramref name="storedProcedureName"/> using the given <paramref name="parameterValues" /> within a transaction and returns the number of rows affected.</para>
        /// </summary>
        /// <param name="transaction">
        /// <para>The <see cref="IDbTransaction"/> to execute the command within.</para>
        /// </param>
        /// <param name="storedProcedureName">
        /// <para>The name of the stored procedure to execute.</para>
        /// </param>
        /// <param name="parameterValues">
        /// <para>An array of parameters to pass to the stored procedure. The parameter values must be in call order as they appear in the stored procedure.</para>
        /// </param>
        /// <returns>
        /// <para>The number of rows affected.</para>
        /// </returns>
        /// <seealso cref="IDbCommand.ExecuteScalar"/>
        //public int ExecuteNonQuery(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        //{
        //    using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
        //    {
        //        return ExecuteNonQuery(command, transaction);
        //    }
        //}


        public void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            LoadDataSet(command, dataSet, new string[] { tableName });
        }

        public void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            using (DbConnection connection = CreateConnection())
            {
                try
                {
                    connection.Open();
                    PrepareCommand(command, connection);
                    DoLoadDataSet(command, dataSet, tableNames);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void DoLoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            if (tableNames == null) throw new ArgumentNullException("tableNames");
            if (tableNames.Length == 0)
            {
                throw new ArgumentException(Resources.ExceptionTableNameArrayEmpty, "tableNames");
            }
            for (int i = 0; i < tableNames.Length; i++)
            {
                if (string.IsNullOrEmpty(tableNames[i])) throw new ArgumentException(Resources.ExceptionNullOrEmptyString, string.Concat("tableNames[", i, "]"));
            }

            using (DbDataAdapter adapter = GetDataAdapter())
            {
                ((IDbDataAdapter)adapter).SelectCommand = command;
                try
                {
                    string systemCreatedTableNameRoot = "Table";
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        string systemCreatedTableName = (i == 0)
                             ? systemCreatedTableNameRoot
                             : systemCreatedTableNameRoot + i;

                        adapter.TableMappings.Add(systemCreatedTableName, tableNames[i]);
                    }

                    adapter.Fill(dataSet);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private object DoExecuteScalar(DbCommand command)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                object returnValue = command.ExecuteScalar();
                return returnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Executes the query for <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The <see cref="DbCommand"/> representing the query to execute.</param>
        /// <returns>The quantity of rows affected.</returns>
        protected int DoExecuteNonQuery(DbCommand command)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected DbDataAdapter GetDataAdapter()
        {
            DbDataAdapter adapter = this._dbProviderFactory.CreateDataAdapter();
            return adapter;
        }


        protected static void PrepareCommand(DbCommand command, DbConnection connection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (connection == null) throw new ArgumentNullException("connection");

            command.Connection = connection;
        }

        /// <summary>
        /// <para>Assigns a <paramref name="transaction"/> to the <paramref name="command"/> and discovers parameters if needed.</para>
        /// </summary>
        /// <param name="command"><para>The command that contains the query to prepare.</para></param>
        /// <param name="transaction">The transaction to assign to the command.</param>
        protected static void PrepareCommand(DbCommand command, DbTransaction transaction)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (transaction == null) throw new ArgumentNullException("transaction");

            PrepareCommand(command, transaction.Connection);
            command.Transaction = transaction;
        }

        public DbCommand GetStoredProcCommand(string storedProcedureName)
        {
            if (string.IsNullOrEmpty(storedProcedureName)) throw new ArgumentException(Resources.ExceptionNullOrEmptyString, "storedProcedureName");

            return CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName);
        }

        /// <summary>
        /// <para>Creates a <see cref="DbCommand"/> for a SQL query.</para>
        /// </summary>
        /// <param name="query"><para>The text of the query.</para></param>        
        /// <returns><para>The <see cref="DbCommand"/> for the SQL query.</para></returns>        
        public DbCommand GetSqlStringCommand(string query)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentException(Resources.ExceptionNullOrEmptyString, "query");

            return CreateCommandByCommandType(CommandType.Text, query);
        }

        private DbCommand CreateCommandByCommandType(CommandType commandType, string commandText)
        {
            DbCommand command = _dbProviderFactory.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;

            return command;
        }

        public void AddInParameter(DbCommand command, string name, DbType dbType)
        {
            AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, null);
        }

        public void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, value);

        }
        public void AddParameter(DbCommand command, string name, DbType dbType, ParameterDirection direction, 
            string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            AddParameter(command, name, dbType, 0, direction, false, 0, 0, sourceColumn, sourceVersion, value);
        }

        public void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction,
            bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DbParameter parameter = CreateParameter(name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            command.Parameters.Add(parameter);
        }

        protected DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            DbParameter param = CreateParameter(name);
            ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            return param;
        }

        /// <summary>
        /// <para>Adds a new instance of a <see cref="DbParameter"/> object.</para>
        /// </summary>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <returns><para>An unconfigured parameter.</para></returns>
        protected DbParameter CreateParameter(string name)
        {
            DbParameter param = this._dbProviderFactory.CreateParameter();
            param.ParameterName = name;
            return param;
        }

        protected void ConfigureParameter(DbParameter param, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            param.DbType = dbType;
            param.Size = size;
            param.Value = (value == null) ? DBNull.Value : value;
            param.Direction = direction;
            param.IsNullable = nullable;
            param.SourceColumn = sourceColumn;
            param.SourceVersion = sourceVersion;
        }
    }
}
