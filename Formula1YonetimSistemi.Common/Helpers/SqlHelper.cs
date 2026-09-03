using Microsoft.Data.SqlClient;

namespace Formula1YonetimSistemi.Common.Helpers
{
    public static class SqlHelper
    {
        // Tüm projenin veritabanı adresi tek bir merkezden yönetilecek
        private static readonly string ConnectionString = @"Data Source=emira-pc\SQLEXPRESS01;Initial Catalog=F1YonetimDB;Integrated Security=True;Encrypt=false;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}