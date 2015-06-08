using System;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Data
{
    public static class DatabaseFactory
    {
        public static Database CreateDatabase()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["DW"].ProviderName);
            Database db = new Database(ConfigurationManager.ConnectionStrings["DW"].ConnectionString, dbProviderFactory);
            return db;
        }

        public static Database CreateDatabase(string name , string connectString)
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(name);
            Database db = new Database(connectString, dbProviderFactory);
            return db;
        }

        public static Database CreateDatabase(string connectName)
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[connectName].ProviderName);
            Database db = new Database(ConfigurationManager.ConnectionStrings[connectName].ConnectionString, dbProviderFactory);
            return db;
        }
    }
}
