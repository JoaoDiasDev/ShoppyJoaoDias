using System;
using System.Collections.Generic;

namespace DAL.MySqlDbContext
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Baskets = new HashSet<Basket>();
            Orderitems = new HashSet<Orderitem>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Resetpasswords = new HashSet<Resetpassword>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? Maillist { get; set; }
        public DateOnly? Birthday { get; set; }
        public int Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Country { get; set; }
        public int? Cityid { get; set; }
        public string? Citytext { get; set; }
        public int? District { get; set; }
        public string? Zipcode { get; set; }
        public string? Valid { get; set; }
        public int? Customertype { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Resetpassword> Resetpasswords { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
