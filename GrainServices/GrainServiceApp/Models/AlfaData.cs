namespace GrainServiceApp.Models
{
    [Immutable, GenerateSerializer]
    public class AlfaData
    {
        [Id(1)]
        public int Id { get; set; }
        [Id(2)]
        public string Name { get; set; }
    }
}
