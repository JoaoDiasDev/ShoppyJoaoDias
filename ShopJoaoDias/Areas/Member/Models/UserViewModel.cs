using Entities;

namespace ShopJoaoDias.Areas.Member.Models
{
    public class UserViewModel
    {
        public UserDO User { get; set; } = new UserDO();
        public List<CityDO> Cities { get; set; } = new List<CityDO>();
        public List<ProvinceDO> Provinces { get; set; } = new List<ProvinceDO>();
    }
}
