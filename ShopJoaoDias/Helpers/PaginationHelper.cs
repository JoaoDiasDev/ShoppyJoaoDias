using Entities;
using ShopJoaoDias.Models;

namespace ShopJoaoDias.Helpers
{
    public class PaginationHelper
    {
        public CategoryProduct CategoryProduct(int totalProduct, int page, CategoryDO category, List<ProductDO> productDOs,
            int perPage = 12, int sort = 1, string minPrice = "", string maxPrice = "", string brandId = "")
        {
            var categoryProduct = new CategoryProduct();
            var pageSizeDots = Math.Ceiling(decimal.Parse(totalProduct.ToString()) / perPage);
            int pageCount = (int)Math.Round(pageSizeDots);
            categoryProduct.TotalCount = totalProduct;
            categoryProduct.PageCount = pageCount;
            categoryProduct.ProductList = productDOs;

            var pageHtml = "";

            if (pageCount > 1)
            {
                for (int i = 1; i < pageCount + 1; i++)
                {
                    var active = i == page ? "is-active" : "";
                    pageHtml += "<li class='" + active + "'><a href='/Category/" + category.Slug + "/" + i + "?minPrice=" + minPrice + "&maxPrice=" + maxPrice + "'>" + i + "</a></li>";
                }

            }
            var html = $@"<ul class='shop-p__pagination'>
                              {pageHtml}
                              </ul>";

            categoryProduct.Html = html;
            return categoryProduct;

        }
    }
}
