using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;


namespace GetDevices.Function
{
    public static class GetDevices
    {
        [FunctionName("GetDevices")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "Devices",
                collectionName: "Devices",
                ConnectionStringSetting = "CosmosDbConnectionString",
                SqlQuery = "SELECT * FROM c order by c._ts desc")]
                IEnumerable<Device> device,
            ILogger log)
        {
          return new OkObjectResult(device);
        }
    }
}
