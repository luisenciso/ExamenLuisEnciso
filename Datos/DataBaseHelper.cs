using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;

namespace Datos
{
    public static class DataBaseHelper
    {
        public static string GetDbConnectionStringSQLServer()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringSQLServer"].ConnectionString;

        }

        public static string GetDbProviderSQLServer()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringSQLServer"].ProviderName;
        }


        public static string GetDbConnectionStringSQLServerPC()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringSQLServerPC"].ConnectionString;
        }

        public static string GetDbProviderSQLServerPC()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringSQLServerPC"].ProviderName;
        }
    }
}
