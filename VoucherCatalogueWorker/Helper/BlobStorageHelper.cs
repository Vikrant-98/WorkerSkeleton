using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helper.BlobService
{
    public class BlobStoragService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobContainerClient _container;
        private readonly ILogger<BlobStoragService> _logger;
        public BlobStoragService(IConfiguration configuration, ILogger<BlobStoragService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _container = new BlobContainerClient(_configuration["BlobStorage:ConnectionString"], _configuration["BlobStorage:ContainerName"]);
        }
    }
}

