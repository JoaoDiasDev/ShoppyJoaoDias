using System.Text.Json.Serialization;

namespace Entities
{
    public partial class WishlistDO
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        [JsonIgnore]
        public virtual ProductDO Product { get; set; } = null!;
        [JsonIgnore]
        public virtual UserDO User { get; set; } = null!;
    }
}
