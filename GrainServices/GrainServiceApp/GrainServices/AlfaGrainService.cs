using GrainServiceApp.Models;
using Orleans.Concurrency;
using Orleans.Runtime;
using Orleans.Services;
using System.Reflection.Metadata.Ecma335;

namespace GrainServiceApp.GrainServices
{
    public interface IAlfaGrainService : IGrainService
    {
        Task<IReadOnlyList<AlfaData>> TestMethod();
    }

    [Reentrant]
    public class AlfaGrainService : GrainService, IAlfaGrainService
    {
        readonly IGrainFactory _grainFactory;
        private readonly ILogger<AlfaGrainService> logger;

        public AlfaGrainService(
            IServiceProvider services,
            Silo silo,
            ILoggerFactory loggerFactory,
            IGrainFactory grainFactory,
            ILogger<AlfaGrainService> logger)
            : base(GrainId.Create(nameof(AlfaGrainService), Guid.Empty.ToString()), silo, loggerFactory)
        {
            _grainFactory = grainFactory;
            this.logger = logger;
        }

        public override Task Init(IServiceProvider serviceProvider) =>
            base.Init(serviceProvider);


        public override Task Start() => base.Start();

        public override Task Stop() => base.Stop();

        public async Task<IReadOnlyList<AlfaData>> TestMethod()
        {
            logger.LogInformation("TestMethod() hit");
            // TODO: custom logic here.
            var data = new List<AlfaData> {
                new AlfaData
                {
                    Id = 1,
                    Name = "Test 1"
                },
                new AlfaData
                {
                    Id = 2,
                    Name = "Test 2"
                }
            };

            return await Task.FromResult(data);
        }
    }
}
