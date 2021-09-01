using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoucherCatalogueWorker.Services.DBServices
{
    public class DBConnectServices
    {
         private readonly ILogger<DBConnectServices> _logger;
        internal DBContext _dbConnect { get; set; }

        private readonly IConfiguration _configuration;
        public DBConnectServices(ILogger<DBConnectServices> logger, IConfiguration configuration, DBContext dbConnect)
        {
            _dbConnect = dbConnect;
            _configuration = configuration;
            _logger = logger;
        }
    }
}
