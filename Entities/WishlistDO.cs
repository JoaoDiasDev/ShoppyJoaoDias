namespace Entities
{
    public partial class WishlistDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual ProductDO Product { get; set; } = null!;
        public virtual UserDO User { get; set; } = null!;
    }
}
