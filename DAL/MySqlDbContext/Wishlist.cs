using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class Wishlist
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Productid { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
