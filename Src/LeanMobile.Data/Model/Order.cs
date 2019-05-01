using System;
using NullGuard;

namespace LeanMobile.Data.Model
{
    public class Order
    {
        public int Id { get; set; }

        [AllowNull]
        public Symbol Symbol { get; set; }

        public decimal Price { get; set; }

        public string PriceCurrency { get; set; }

        public OrderStatus Status { get; set; }

        public OrderType Type { get; set; }

        public DateTime Time { get; set; }

        public DateTime? LastFillTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public DateTime? CanceledTime { get; set; }

        public decimal Quantity { get; set; }
    }
}