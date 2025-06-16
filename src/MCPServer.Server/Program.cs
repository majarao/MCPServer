using MCPServer.Shared.Clients;
using MCPServer.Shared.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(PessoaTools).Assembly);

builder.Services.AddHttpClient<PessoaClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5101/api/");
});

IHost app = builder.Build();

await app.RunAsync();