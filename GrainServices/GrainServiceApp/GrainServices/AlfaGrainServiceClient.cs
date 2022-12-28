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
            var service = GetGrainService(CurrentGrainReference.GrainId);

            return service.TestMethod();
        }
    }
}
