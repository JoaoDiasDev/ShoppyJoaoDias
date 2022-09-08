namespace Entities
{
    public partial class ProvinceDO
    {
        public ProvinceDO()
        {
            Cities = new List<CityDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Order { get; set; }

        public virtual List<CityDO> Cities { get; set; }
    }
}
