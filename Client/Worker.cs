using MassTransit;
using Newtonsoft.Json;
using System.Text.Json;

namespace Client
{
    public class Worker : BackgroundService, IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        public Worker(ILogger<Worker> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var products = new List<Product>();

            for (int i = 1; i <= 5000; i++)
            {
                products.Add(new Product { Id = i, ProductName = $"ProductName {i}", DateTime = DateTime.Now, Amount = 5 });

                var productJson = JsonConvert.SerializeObject(products);

                //await _publishEndpoint.Publish(productJson);

                //await _publishEndpoint.Publish(new Product
                // {
                //     Id = i,
                //     ProductName = $"ProductName {i}",
                //     DateTime = DateTime.Now,
                //     Amount = 5
                // });
            }





            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}