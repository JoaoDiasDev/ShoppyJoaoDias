using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ProductDO Product { get; set; } = null!;
        [JsonIgnore]
        public virtual UserDO User { get; set; } = null!;
    }
}
