namespace Entities
{
    public class CityDO
    {
        public CityDO()
        {
            Addresses = new List<AddressDO>();
            Users = new List<UserDO>();
        }

        public int Id { get; set; }
        public int Provinceid { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public int? Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ProvinceDO Province { get; set; } = null!;
        public virtual List<AddressDO> Addresses { get; set; }
        public virtual List<UserDO> Users { get; set; }
    }
}
