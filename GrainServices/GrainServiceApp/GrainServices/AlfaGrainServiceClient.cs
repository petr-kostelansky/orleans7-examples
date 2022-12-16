using GrainServiceApp.Models;
using Orleans.Runtime;
using Orleans.Runtime.Services;
using Orleans.Services;

namespace GrainServiceApp.GrainServices
{
    public interface IAlfaGrainServiceClient : IGrainServiceClient<IAlfaGrainService>, IAlfaGrainService
    {
    }

    public class AlfaGrainServiceClient : GrainServiceClient<IAlfaGrainService>, IAlfaGrainServiceClient
    {
        public AlfaGrainServiceClient(
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        public Task<IReadOnlyList<AlfaData>> TestMethod()
        {
            // Not sure how get grainService reference:
            var grainId = GrainId.Create(nameof(AlfaGrainService), Guid.Empty.ToString());
            var service = GetGrainService(grainId);
            // -------------------------------------

            return service.TestMethod();
        }
    }
}
