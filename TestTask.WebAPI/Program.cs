using TestTask.BLL.Extensions;
using TestTask.DAL.Extensions;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettingsFileName = "appsettings";
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile($"{appSettingsFileName}.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"{appSettingsFileName}.{builder.Environment.EnvironmentName}.json", reloadOnChange: true, optional: true)
    .AddEnvironmentVariables()
    .Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper();
builder.Services.RegisterCustomServices();
builder.Services.AddTestTaskContext(builder.Configuration);


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