using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.IO;

namespace Datos
{
    public class Db
    {

        static StringBuilder errorMessages;

        #region "Get y Set Atributos de Conexion"


        private static string vSQL_Cadena_Conexion = (Convert.ToBoolean(ConfigurationManager.AppSettings["UseCnEncryp"].ToString())) ? EncryptionHelper.Desencriptar(ConfigurationManager.ConnectionStrings["ConnectionStringSQLServer"].ConnectionString) : ConfigurationManager.ConnectionStrings["ConnectionStringSQLServer"].ConnectionString;

        private static string SQL_Cadena_Conexion
        {
            set
            {
                vSQL_Cadena_Conexion = value;
            }
            get
            {
                return vSQL_Cadena_Conexion;
            }
        }


        private static IDbTransaction MTransaccion;
        private static IDbConnection CrearConexion(string cadena)
        {
            return new System.Data.SqlClient.SqlConnection(cadena);
        }
        private static IDbConnection MConexion;
        private static IDbConnection Conexion
        {
            get
            {
                // si aun no tiene asignada la cadena de conexion lo hace
                if (MConexion == null)
                    MConexion = CrearConexion(SQL_Cadena_Conexion);


                // si no esta abierta aun la conexion, lo abre
                if (MConexion.State != ConnectionState.Open)
                    MConexion.Open();

                // retorna la conexion en modo interfaz, para que se adapte a cualquier implementacion de los distintos fabricantes de motores de bases de datos
                return MConexion;
            } // end get
        } // end Conexion

        #endregion





        #region "Control de Transacciones"

        protected bool EnTransaccion;
        //Comienza una Transacción en la base en uso. 
        private void IniciarTransaccion()
        {
            try
            {
                MTransaccion = Conexion.BeginTransaction();
                EnTransaccion = true;
            }// end try
            finally
            { EnTransaccion = false; }
        }// end IniciarTransaccion
        //Confirma la transacción activa. 
        private void TerminarTransaccion()
        {
            try
            { MTransaccion.Commit(); }
            finally
            {
                MTransaccion = null;
                EnTransaccion = false;
            }// end finally
        }// end TerminarTransaccion
        //Cancela la transacción activa.
        private void AbortarTransaccion()
        {
            try
            { MTransaccion.Rollback(); }
            finally
            {
                MTransaccion = null;
                EnTransaccion = false;
            }// end finally
        }// end AbortarTransaccion

        #endregion





        #region "Creacion de Comandos y Adaptadores"
        protected static SqlCommand Comando(string ProcedureStore)
        {
            errorMessages = new StringBuilder();
            SqlCommand com;
            try
            {
                SqlConnection cn = new SqlConnection(SQL_Cadena_Conexion);
                cn.Open();
                com = new SqlCommand(ProcedureStore, cn) { CommandType = CommandType.StoredProcedure, CommandTimeout = 200 };
                SqlCommandBuilder.DeriveParameters(com);
                cn.Close();
                com.Connection = (SqlConnection)Conexion;
                com.Transaction = (SqlTransaction)MTransaccion;
                //GenerateLog("Se ejecuto => " + ProcedureStore + " " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                return com;
            }
            catch (SqlException ex)
            {
                /*
                string h = Directory.GetCurrentDirectory();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    GenerateLog(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()+ " +Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }*/
                return null;
            }
        }







        /*protected static SqlCommand Comando_sql(string ComandoSql)
        {
            var com = new SqlCommand(ComandoSql, (SqlConnection)Conexion, (SqlTransaction)MTransaccion);
            return com;
        }*/

        protected static void Cargar_Parametros(IDbCommand com, Object[] Argumentos)
        {
            for (Int32 i = 1; i < com.Parameters.Count; i++)
            {
                var Para = (SqlParameter)com.Parameters[i];
                Para.Value = i <= Argumentos.Length ? Argumentos[i - 1] : null;
            }
        }
        protected static IDataAdapter CrearDataAdapter(string procedureAlmacenado, params Object[] argumentos)
        {
            var da = new SqlDataAdapter((SqlCommand)Comando(procedureAlmacenado));
            if (argumentos.Length != 0)
            {
                Cargar_Parametros(da.SelectCommand, argumentos);
            }
            return da;
        }
        /*protected static IDataAdapter CrearDataAdapterSql(string ComandoSQL)
        {
            var da = new SqlDataAdapter((SqlCommand)Comando_sql(ComandoSQL));
            return da;
        }*/
        #endregion

        #region "Obtencion de Coleccion Datos Tipo Datatable"
        // Obtiene un DataTable a partir de un Procedimiento Almacenado.
        public static DataTable TraerDataTable(string procedimientoAlmacenado)
        { return (TraerDataSet(procedimientoAlmacenado).Tables.Count != -1) ? TraerDataSet(procedimientoAlmacenado).Tables[0].Copy() : null; } // end TraerDataTable
        //Obtiene un DataSet a partir de un Procedimiento Almacenado y sus parámetros. 
        public static DataTable TraerDataTable(string procedimientoAlmacenado, params Object[] args)
        {
            try
            {
                return TraerDataSet(procedimientoAlmacenado, args).Tables[0].Copy();
            }
            catch (Exception)
            {
                return null;
            }
        } // end TraerDataTable
        //Obtiene un DataTable a partir de un Query SQL
        /*public static DataTable TraerDataTableSql(string comandoSql)
        { return TraerDataSetSql(comandoSql).Tables[0].Copy(); } // end TraerDataTableSql*/
        #endregion

        #region "Ejecutores de Sentencias SQL sin respuesta"
        // Ejecuta un Procedimiento Almacenado en la base. 
        public static int Ejecutar(string procedimientoAlmacenado)
        { return Comando(procedimientoAlmacenado).ExecuteNonQuery(); } // end Ejecutar
        // Ejecuta un query sql
        /*public static int EjecutarSql(string comandoSql)
        { return Comando_sql(comandoSql).ExecuteNonQuery(); } // end Ejecutar*/
        //Ejecuta un Procedimiento Almacenado en la base, utilizando los parámetros. 
        public static int Ejecutar(string procedimientoAlmacenado, params Object[] argumentos)
        {
            var com = Comando(procedimientoAlmacenado);
            Cargar_Parametros(com, argumentos);
            var resp = com.ExecuteNonQuery();
            for (var i = 0; i < com.Parameters.Count; i++)
            {
                var par = (IDbDataParameter)com.Parameters[i];
                if (par.Direction == ParameterDirection.InputOutput || par.Direction == ParameterDirection.Output)
                    argumentos.SetValue(par.Value, i - 1);
            }// end for
            return resp;
        } // end Ejecutar
        #endregion

        #region "Obtencion de Coleccion Datos Tipo Dataset"
        // Obtiene un DataSet a partir de un Procedimiento Almacenado.
        public static DataSet TraerDataSet(string procedimientoAlmacenado)
        {
            var mDataSet = new DataSet();
            CrearDataAdapter(procedimientoAlmacenado).Fill(mDataSet);
            return mDataSet;
        } // end TraerDataset
        //Obtiene un DataSet a partir de un Procedimiento Almacenado y sus parámetros. 
        public static DataSet TraerDataSet(string procedimientoAlmacenado, params Object[] args)
        {
            var mDataSet = new DataSet();
            CrearDataAdapter(procedimientoAlmacenado, args).Fill(mDataSet);
            return mDataSet;
        } // end TraerDataset
        // Obtiene un DataSet a partir de un Query Sql.
        /*public static DataSet TraerDataSetSql(string comandoSql)
        {
            var mDataSet = new DataSet();
            CrearDataAdapterSql(comandoSql).Fill(mDataSet);
            return mDataSet;
        } // end TraerDataSetSql*/
        #endregion

        static bool Autenticar()
        {
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();
            return true;

        }


        private static void GenerateLog(string message)
        {

            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\LOG"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\LOG");
                }
                System.IO.StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\LOG\\log.txt", true);
                file.WriteLine(message);
                file.Flush();
                Console.WriteLine("archivo generado" + " " + Directory.GetCurrentDirectory() + "\\LOG");
            }
            catch (Exception)
            {

            }
        }

    }
}
