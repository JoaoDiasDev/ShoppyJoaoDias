namespace Entities
{
    public partial class ProductImageDO
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public string Address { get; set; } = null!;
        public int Orderby { get; set; }

        public virtual ProductDO Product { get; set; } = null!;
    }
}
