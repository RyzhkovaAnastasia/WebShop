using WebShop.Core.Configs;
using WebShop.Mappers;
using Serilog;
using Serilog.Events;
using System.Text.Json;
using WebShop.Configs;

var builder = WebApplication.CreateBuilder(args);
var path = Environment.CurrentDirectory;

var configuration = builder.Configuration
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext();
});

builder.Services.Configure<Values>(options => configuration.Bind("Values", options));

Log.Logger = new LoggerConfiguration()
            .WriteTo.File(builder.Configuration.GetValue<string>("Values:LogsFile"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

Log.Information("Application started at {FolderPath}", path);

Log.Information("Configuration values: {ConfigValues}", JsonSerializer.Serialize(configuration.GetSection("Values").Get<Values>()));

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:NorthwindConnectionString");
_ = new CoreDependencyResolver(builder.Services, connectionString);
builder.Services.AddTransient<ProductMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
