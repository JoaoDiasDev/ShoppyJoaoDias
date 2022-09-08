namespace Entities
{
    public partial class UnitDO
    {
        public UnitDO()
        {
            Products = new List<ProductDO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Shortname { get; set; }

        public virtual List<ProductDO> Products { get; set; }
    }
}
