namespace DAL.MySqlDbContext
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int Provinceid { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; }
        public int? Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
