using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FB2SQL
{
    public class DBContext
    {
        private string _connstring;

        public DBContext(string connstring)
        {
            _connstring = connstring;
        }
        public DataTable ReadFromDBToDataTable(string query, params object[] parameters)
        {
            DataTable table = new DataTable();
            OdbcConnection conn = OpenConnection();
            OdbcDataAdapter sda = new OdbcDataAdapter(query, conn);

            for (int i = 0; i < parameters.Length; i++)
            {
                sda.SelectCommand.Parameters.AddWithValue("@" + i, parameters[i]);
            }

            try
            {
                sda.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                if (!Object.ReferenceEquals(sda, null))
                    sda.Dispose();
            }
            return table;
        }

        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            int RowsAffected = 0;
            OdbcCommand command = null;
            try
            {
                command = new OdbcCommand();

                command.Connection = OpenConnection();

                command.CommandText = sql;

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + i, parameters[i]);
                }

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                command.Connection.Close();
                if (!Object.ReferenceEquals(command, null))
                    command.Dispose();
            }
            return RowsAffected;
        }

        private OdbcDataReader ExecuteQueryGetReader(string sqlText, OdbcConnection conn, object[] parameters)
        {
            OdbcCommand command = null;
            OdbcDataReader reader = null;
            try
            {
                command = new OdbcCommand(sqlText, conn);

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + i, parameters[i]);
                }

                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (!Object.ReferenceEquals(command, null))
                //    command.Dispose();
            }
            return reader;
        }

        //public static int GetLastInsertID()
        //{
        //    return ReadFirstFieldAsInt("SELECT LAST_INSERT_ID()");
        //}

        public int ExecuteAndGetLastInsertID(string sql, params object[] parameters)
        {
            int RowsAffected = 0;
            int LastInsertID = 0;
            OdbcCommand command = null;
            OdbcDataReader reader = null;
            try
            {
                command = new OdbcCommand();

                command.Connection = OpenConnection();

                command.CommandText = sql;

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.AddWithValue("@" + i, parameters[i]);
                }

                RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    reader = ExecuteQueryGetReader("SELECT LAST_INSERT_ID()", command.Connection, parameters);

                    if (reader.HasRows)
                    {
                        reader.Read();
                        LastInsertID = Convert.ToInt32(reader[0]);
                    }

                    if (!Object.ReferenceEquals(reader, null))
                        reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                command.Connection.Close();
                if (!Object.ReferenceEquals(command, null))
                    command.Dispose();
            }
            return LastInsertID;
        }

        public int ReadFirstFieldAsInt(string sqlText, params object[] parameters)
        {
            int result = -1;
            OdbcDataReader reader = null;
            OdbcConnection conn = OpenConnection();
            //result = defaultResult;
            reader = ExecuteQueryGetReader(sqlText, conn, parameters);

            if (reader.HasRows)
            {
                reader.Read();
                result = Convert.ToInt32(reader[0]);
            }

            if (!Object.ReferenceEquals(reader, null))
                reader.Close();
            conn.Close();

            return result;
        }

        public string ReadFirstFieldAsString(string sqlText, params object[] parameters)
        {
            string result = "";
            OdbcDataReader reader = null;
            OdbcConnection conn = OpenConnection();

            //result = defaultResult;
            reader = ExecuteQueryGetReader(sqlText, conn, parameters);

            if (reader.HasRows)
            {
                reader.Read();
                result = Convert.ToString(reader[0]);
            }

            if (!Object.ReferenceEquals(reader, null))
                reader.Close();
            conn.Close();

            return result;
        }

        // function that creates an object from the given data row
        public T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }

        private void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            int i = 0;
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                PropertyInfo p = item.GetType().GetProperties().OrderBy(x => x.MetadataToken).ElementAt(i);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, Convert.ChangeType(row[c], p.PropertyType, CultureInfo.InvariantCulture), null);
                    if (p.PropertyType == Type.GetType("decimal"))
                    {
                        decimal.Round((decimal)p.GetValue(item), 2, MidpointRounding.AwayFromZero);
                    }
                }
                else if (row[c] == DBNull.Value)
                {
                    p.SetValue(item, String.Empty, null);
                }

                i++;
            }
        }

        private OdbcConnection OpenConnection()
        {
            OdbcConnection OdbcConn = null;

            OdbcConn = new OdbcConnection();

            OdbcConn.ConnectionString = _connstring;
            OdbcConn.Open();

            return OdbcConn;
        }
    }
}