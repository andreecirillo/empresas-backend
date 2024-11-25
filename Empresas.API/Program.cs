using Empresas.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var commandConnectionString = builder.Configuration.GetConnectionString("CommandConnection")
    ?? throw new InvalidOperationException("CommandConnection string is not configured.");

var queryConnectionString = builder.Configuration.GetConnectionString("QueryConnection")
    ?? throw new InvalidOperationException("QueryConnection string is not configured.");

builder.Services.AddApplicationServices(commandConnectionString, queryConnectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
