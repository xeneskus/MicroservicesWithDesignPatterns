using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaOrchestrationBasedPattern.Shared;
using SagaOrchestrationBasedPattern.Stock.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("StockDb");
});

builder.Services.AddMassTransit(x =>
{
    //x.AddConsumer<OrderCreatedEventConsumer>();
    //x.AddConsumer<StockRollBackMessageConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        cfg.ReceiveEndpoint(RabbitMQSettingsConst.StockOrderCreatedEventQueueName, e =>
        {
            //e.ConfigureConsumer<OrderCreatedEventConsumer>(context);//hangi consumer dinleyeceðini belirttik
        });//sub olduk
        //cfg.ReceiveEndpoint(Shared.RabbitMQSettingsConst.StockRollBackMessageQueueName, e =>
        //{
        //    e.ConfigureConsumer<StockRollBackMessageConsumer>(context);
        //});
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Stocks.Add(new SagaOrchestrationBasedPattern.Stock.API.Models.Stock() { Id = 1, ProductId = 1, Count = 100 });
    context.Stocks.Add(new SagaOrchestrationBasedPattern.Stock.API.Models.Stock() { Id = 2, ProductId = 2, Count = 200 });
    context.SaveChanges();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
