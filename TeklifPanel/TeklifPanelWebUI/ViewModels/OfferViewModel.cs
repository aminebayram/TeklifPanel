using TeklifPanel.Entity;

namespace TeklifPanelWebUI.ViewModels
{
    public class OfferViewModel
    {
        public string Pdf { get; set; }
        public string OrderNumber { get; set; } //Siparis Numarasi
        public decimal? BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? KDV { get; set; }
        public DateTime DateOfOffer { get; set; }
        public int CustomerId { get; set; }
        public int CustomerContactId { get; set; }
        public List<int> Products { get; set; }

    }
}
