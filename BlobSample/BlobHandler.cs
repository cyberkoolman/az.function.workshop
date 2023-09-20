using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BlobSample
{
    public class BlobHandler
    {
        private readonly ILogger<BlobHandler> _logger;

        public BlobHandler(ILogger<BlobHandler> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobHandler))]
        public async Task Run([BlobTrigger("fis-dev/{name}", Connection = "")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
