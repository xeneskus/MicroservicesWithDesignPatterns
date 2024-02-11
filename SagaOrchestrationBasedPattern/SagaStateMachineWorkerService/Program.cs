using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaOrchestrationBasedPattern.SagaStateMachineWorkerService.Models;
using SagaOrchestrationBasedPattern.Shared;
using SagaStateMachineWorkerService;
using SagaStateMachineWorkerService.Models;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

        services.AddMassTransit(cfg =>
        {
            cfg.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>().EntityFrameworkRepository(opt =>
            {
                opt.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                {
                    builder.UseSqlServer(configuration.GetConnectionString("SqlCon"), m =>
                    {
                        m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    });
                });
           
            });

            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
            {
                configure.Host(configuration.GetConnectionString("RabbitMQ"));

                configure.ReceiveEndpoint(RabbitMQSettingsConst.OrderSaga, e => //bu kuyruða bir mesaj geldiði zaman tetiklenecek
                {
                    e.ConfigureSaga<OrderStateInstance>(provider);//her bir mesaj geldiðinde bir nesne örneði oluþturulacak ve veritabanýna yazýlacak
                });
            }));
        });




        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
