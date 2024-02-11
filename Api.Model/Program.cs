using Api.Model;
using Api.Model.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = CreateHostBuilder(args).Build();

using var serviceScope = host.Services.CreateScope();
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (hostContext, services) =>
            {
                services.AddApiContext(hostContext.Configuration);
            });
