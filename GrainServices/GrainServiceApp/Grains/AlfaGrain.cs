using GrainServiceApp.GrainServices;
using GrainServiceApp.Models;

namespace GrainServiceApp.Grains
{
    public interface IAlfaGrain: IGrainWithStringKey
    {
        Task<IReadOnlyList<AlfaData>> LoadData();
    }

    public class AlfaGrain: Grain, IAlfaGrain
    {
        private readonly IAlfaGrainServiceClient alfaGrainServiceClient;

        public AlfaGrain(
            IAlfaGrainServiceClient alfaGrainServiceClient)
        {
            this.alfaGrainServiceClient = alfaGrainServiceClient;
        }

        public async Task<IReadOnlyList<AlfaData>> LoadData()
        {
            return await alfaGrainServiceClient.TestMethod();
        }
    }
}
