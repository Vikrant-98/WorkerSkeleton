using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VoucherCatalogueWorker.Process;

namespace VoucherCatalogueWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
         private readonly IConfiguration _configuration;
        private readonly Processor _Process;

        public Worker(ILogger<Worker> logger,Processor Process,IConfiguration configuration)
        {
            _logger = logger;
            _Process = Process;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var isStopProcess = _configuration["IsStopProcess"];
            if (!String.IsNullOrEmpty(isStopProcess) && "No".Equals(isStopProcess))
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await _Process.Process();
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
