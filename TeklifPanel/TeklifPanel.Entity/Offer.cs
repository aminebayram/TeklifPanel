using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Offer
    {
        public Offer()
        {
            ProductOffers = new List<ProductOffer>();
        }
        public int Id { get; set; }
        public DateTime DateOfSend  { get; set; } // Gönderme Tarihi
        public DateTime DateOfForwarded { get; set; } // İletildi/teslime edildi tarihi
        public DateTime DateOfRead { get; set; } // Okundu tarihi
        public bool IsForwarded { get; set; } // İletildi mi?
        public bool IsRead { get; set; } // Okundu mu?
        public string Pdf { get; set; }
        public string OrderNumber { get; set; } //Siparis Numarasi
        public decimal? BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? KDV { get; set; }
        public DateTime DateOfOffer { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public CustomerContact CustomerContact { get; set; }
        public int CustomerContactId { get; set; }
        public List<ProductOffer> ProductOffers { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
