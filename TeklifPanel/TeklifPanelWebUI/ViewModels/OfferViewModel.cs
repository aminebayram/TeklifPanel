using TeklifPanel.Entity;

namespace TeklifPanelWebUI.ViewModels
{
    public class OfferViewModel
    {
        public string Pdf { get; set; }
        public int OrderNumber { get; set; } //Siparis Numarasi
        public decimal? SellPrice { get; set; }
        public decimal? KDV { get; set; }
        public string DateOfOffer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactName{ get; set; }
        public string CustomerAddress { get; set; }
        public string CompanyName { get; set; }
        public CompanySettingsViewModel CompanySettingsViewModel { get; set; }
        public List<ProductViewModel> ProductsViewModel { get; set; }
        public Company Company { get; set; }
        public Customer Customer { get; set; }
        public CustomerContact CustomerContact { get; set; }
    }
}
