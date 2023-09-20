using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using User.API.Model;
using System.Collections.Generic;

namespace User.API
{
    public static class GetUsers
    {
        [FunctionName("GetUsers")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",
            Route = "users")] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            string usersFile = Path.Combine(context.FunctionAppDirectory, "users.json");
            string itemsJson = File.ReadAllText(usersFile);

            var items = JsonConvert.DeserializeObject<List<Customer>>(itemsJson);

            return new OkObjectResult(items);
        }
    }
}
