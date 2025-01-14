using MessageHawk.Inbox.Infrastructure.Configurations;
using MessageHawk.Inbox.Infrastructure.Extensions;
using MessageHawk.Inbox.Application.Configurations;
using MessageHawk.Inbox.Application.MessageBroker;

var builder = WebApplication.CreateBuilder(args);
var connectionStringSqlite = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RepositoriesDependencies();
builder.Services.ServicesDependencies();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MessageHawk.Inbox.WebAPI (Consumer)",
        Version = "v1"
    });
    c.EnableAnnotations();
});

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSqliteDbContext(connectionStringSqlite);
builder.Services.AddHostedService<MessageHawkConsumerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
