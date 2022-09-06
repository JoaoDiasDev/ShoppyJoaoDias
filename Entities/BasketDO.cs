namespace Entities
{
    public class BasketDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public int Piece { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ProductDO Product { get; set; } = null!;
        public virtual UserDO User { get; set; } = null!;
    }
}
