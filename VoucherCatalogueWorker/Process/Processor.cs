using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace VoucherCatalogueWorker.Process
{
    public class Processor
    {
        private readonly ILogger<Processor> _logger;
        private readonly IConfiguration _configuration;
        public Processor(ILogger<Processor> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task Process() 
        {
            _logger.LogInformation("Hello There.....Logs");
            Console.WriteLine("Hello There.....Logs");
        }
       
    } 
}
