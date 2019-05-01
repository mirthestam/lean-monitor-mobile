using NullGuard;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LeanMobile.Algorithms.Results
{
    public class Order : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Symbol { get; set; }

        public decimal FillPrice { get; set; }

        public decimal Quantity { get; set; }

        public OrderType OrderType { get; set; }

        public OrderStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}