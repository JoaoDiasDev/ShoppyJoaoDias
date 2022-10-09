using Entities;

namespace ShopJoaoDias.Areas.Admin.Models
{
    public class CityViewModel
    {
        public CityDO CityDO { get; set; } = new CityDO();
        public List<CityDO> CityDOList { get; set; } = new List<CityDO>();
        public List<ProvinceDO> ProvinceDOList { get; set; } = new List<ProvinceDO>();
    }
}
