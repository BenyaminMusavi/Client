using Client;
using MassTransit;
using MassTransit.Util;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //services.AddMassTransit(serviceCollectionConfigurator =>
        //{
        //    //serviceCollectionConfigurator.AddBus(serviceProvider =>
        //    //     Bus.Factory.CreateUsingRabbitMq(busFactoryConfigurator =>
        //    //     {
        //    //         busFactoryConfigurator.Host("localhost/15672", h =>
        //    //         {
        //    //             h.Username("guest");
        //    //             h.Password("guest");
        //    //         });
        //    //         //busFactoryConfigurator.ReceiveEndpoint("responder2_request2_endpoint",
        //    //         //  endpointConfigurator =>
        //    //         //  {
        //    //         //      endpointConfigurator.Consumer<Request2Consumer>(serviceProvider);
        //    //         //  });
        //    //     }));
        //});

        //=============================================
        services.AddHostedService<Worker>();

        // services.AddScoped<Worker>();
        //  services.AddHostedService<Worker>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                //cfg.Host("localhost", "/", h =>
                //{
                //    h.Username("guest");
                //    h.Password("guest");
                //});

                cfg.Host("rabbitmq://guest:guest@localhost:5672");
            });
        });



        //services.AddMassTransit(config =>
        //{
        //    config.UsingRabbitMq((ctx, cfg) =>
        //    {
        //        var rabbitConnection = hostContext.Configuration.GetConnectionString("RabbitConnection");
        //        cfg.Host(rabbitConnection);
        //    });
        //});
    })
    .Build();


await host.RunAsync();



//partial class Program
//{
//    public static void Main(string[] args)
//    {
//        var host = CreateHostBuilder(args).Build();

//        var logger = host.Services.GetRequiredService<ILogger<Program>>();
//        logger.LogInformation("Responder2 running.");
//        host.Run();
//    }

//    IHost host = Host.CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//        .ConfigureServices((hostContext, services) =>
//        {
//            services.AddMassTransit(config =>
//            {
//                config.UsingRabbitMq((ctx, cfg) =>
//                {
//                    var rabbitConnection = hostContext.Configuration.GetConnectionString("RabbitConnection");
//                    cfg.Host(rabbitConnection);
//                });
//            });


//        });

//    IHost host = Host.CreateDefaultBuilder(args)
//            .ConfigureServices(services =>
//            {
//                services.AddHostedService<Worker>();
//            })
//            .Build();

//    services.AddHostedService<Worker>();

//            await host.RunAsync();
//}

