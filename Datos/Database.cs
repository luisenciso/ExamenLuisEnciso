using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace Datos
{
    public class Database : IDisposable
    {
        DbConnection connection;
        DbProviderFactory factory;
        public DbCommand command;
        //public static bool sw;
        public string ls_bd = "";

        public Database()
        {
            factory = DbProviderFactories.GetFactory(DataBaseHelper.GetDbProviderSQLServer());
        }

        public Database(string pc)
        {
            ls_bd = pc;
            factory = DbProviderFactories.GetFactory(DataBaseHelper.GetDbProviderSQLServerPC());
        }

        public void Open()
        {
            connection = factory.CreateConnection();
            if (ls_bd.Equals("PC"))
                connection.ConnectionString = DataBaseHelper.GetDbConnectionStringSQLServerPC();
            else
                connection.ConnectionString = DataBaseHelper.GetDbConnectionStringSQLServer();

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public string CommandText
        {
            set
            {
                if (command == null)
                {
                    command = factory.CreateCommand();

                }
                if (connection == null)
                {
                    this.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = value;
            }
        }

        public string ProcedureName
        {
            set
            {
                if (command == null)
                {
                    command = factory.CreateCommand();
                }
                if (connection == null)
                {
                    this.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = value;
            }
        }

        public void AddParameter(string parameterName, DbType parameterType, ParameterDirection parameterDirection, Object parameterValue)
        {
            if (command != null)
            {
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = parameterName;
                parameter.DbType = parameterType;
                parameter.Direction = parameterDirection;
                parameter.Value = parameterValue;
                command.Parameters.Add(parameter);
            }
        }

        public IDataReader GetDataReader()
        {
            return command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
        }

        public int Execute()
        {
            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return command.ExecuteScalar();
        }

        ~Database()
        {
            this.Dispose();
        }

        #region IDisposable Members

        public void Dispose()
        {
            /*if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();*/
            connection = null;
            command = null;
            factory = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion
    }



    [Serializable]
    #region FactoryNullableTypes
    public sealed class FactoryNullableTypes
    {
        public static System.String getString(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return rdr.GetString(col);
        }

        public static System.String getString(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return rdr[col].ToString();
        }

        public static Nullable<System.Double> getDouble(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDouble(rdr[col]);

        }

        public static Nullable<System.Double> getDouble(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDouble(rdr[col]);
        }

        public static Nullable<System.Decimal> getDecimal(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDecimal(rdr[col]);

        }

        public static Nullable<System.Decimal> getDecimal(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDecimal(rdr[col]);
        }

        public static Nullable<System.Int16> getInt16(IDataReader rdr, int col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt16(rdr[col]);
        }

        public static Nullable<System.Int16> getInt16(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt16(rdr[col]);
        }

        public static Nullable<System.Int32> getInt32(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt32(rdr[col]);
        }

        public static Nullable<System.Int32> getInt32(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt32(rdr[col]);

        }

        public static Nullable<System.Int64> getInt64(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt64(rdr[col]);

        }

        public static Nullable<System.Int64> getInt64(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt64(rdr[col]);
        }

        public static Nullable<System.DateTime> getDateTime(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDateTime(rdr[col]);
        }

        public static Nullable<System.DateTime> getDateTime(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToDateTime(rdr[col]);
        }

        public static Nullable<System.Boolean> getBoolean(IDataReader rdr, int col)
        {
            if (rdr.GetValue(col).Equals(DBNull.Value))
                return null;
            else
                return Convert.ToBoolean(rdr[col]);
        }

        public static Nullable<System.Boolean> getBoolean(IDataReader rdr, string col)
        {
            if (rdr[col].Equals(DBNull.Value))
                return null;
            else
                return Convert.ToBoolean(rdr[col]);
        }
    }
    #endregion FactoryNullableTypes

}
