
using System.Configuration;

namespace NHibernateTest.Utility
{
    class NHibernateCfgPicker
    {

        public static string GetCfgFilePath()
        {
            string dbCfgFilePath = string.Empty;

            if (ConfigurationManager.AppSettings["mysqlDb"] != null)
            {
                dbCfgFilePath = ConfigurationManager.AppSettings["mysqlDb"];
            }
            else if (ConfigurationManager.AppSettings["sqlserverDb"] != null)
            {
                dbCfgFilePath = ConfigurationManager.AppSettings["sqlserverDb"];
            }

            return "Config/" + dbCfgFilePath;
        }
    }
}
