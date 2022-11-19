using Entities;

namespace ShopJoaoDias.Models
{
    public class AddressViewModel
    {
        public List<CityDO> Cities { get; set; } = new List<CityDO>();
        public List<ProvinceDO> Provinces { get; set; } = new List<ProvinceDO>();
        public CityDO City { get; set; } = new CityDO();
        public AddressDO Address { get; set; } = new AddressDO();
        public List<AddressDO> AddressList { get; set; } = new List<AddressDO>();
    }
}
