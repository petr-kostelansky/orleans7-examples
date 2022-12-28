using GrainServiceApp.GrainServices;
using Orleans.Configuration;

namespace GrainServiceApp
{
    public static class OrleansConfigurations
    {
        public static WebApplicationBuilder SetupOrleans(this WebApplicationBuilder builder)
        {
            builder.Host
                .UseOrleans((HostBuilderContext context, ISiloBuilder siloBuilder) =>
                {
                    siloBuilder
                    .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000, listenOnAnyHostAddress: true)
                    .UseLocalhostClustering(siloPort: 11111, gatewayPort: 30000)
                    .Configure<ClusterOptions>(options =>
                    {
                        options.ClusterId = "dev";
                        options.ServiceId = "dev";
                    })
                    .AddMemoryGrainStorageAsDefault()
                    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole());

                    // Grain service registration:
                    siloBuilder
                    .AddGrainService<AlfaGrainService>()
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<IAlfaGrainServiceClient, AlfaGrainServiceClient>();
                    });
                });

            return builder;
        }
    }
}
