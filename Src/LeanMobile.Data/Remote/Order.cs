using System;

namespace LeanMobile.Data.Remote
{
    public abstract class Order
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string PriceCurrency {get; set; }

        public DateTime Time { get; set; }

        public DateTime? LastFillTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public DateTime? CanceledTime { get; set; }

        public decimal Quantity { get; set; }        
    }    
}