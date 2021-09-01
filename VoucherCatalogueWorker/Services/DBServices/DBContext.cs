using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoucherCatalogueWorker.Services.DBServices
{
    public class DBContext
    {
        public MySqlConnection Connection { get; }

        public DBContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }
        public void Dispose() => Connection.Dispose();
    }
}
