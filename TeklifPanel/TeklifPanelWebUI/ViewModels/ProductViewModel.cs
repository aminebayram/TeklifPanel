using TeklifPanel.Entity;

namespace TeklifPanelWebUI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public List<ProductOffer> ProductOffers { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<string> Images { get; set; }
        public int CompanyId { get; set; }
    }
}
