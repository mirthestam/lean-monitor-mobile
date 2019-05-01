using LeanMobile.Algorithms.Results;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Orders
{
    public class OrdersViewViewModel : BindableBase
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        public OrdersViewViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            algorithmResults
                .Select(r => r.Orders)
                .SelectMany(o => o.Items.OrderBy(i => i.DateTime))
                .Subscribe(o =>
                {
                    if (o == null) return;

                    var existingOrder = Orders.SingleOrDefault(i => i.Id == o.Id);
                    if (existingOrder != null)
                    {
                        // Update the order
                        existingOrder.DateTime = o.DateTime;
                        existingOrder.FillPrice = o.FillPrice;
                        existingOrder.Quantity = o.Quantity;
                        existingOrder.Status = o.Status;
                    }
                    else
                    {
                        // This is a new order
                        // TODO: This will fail in order when  multiple new orders are present
                        Orders.Insert(0, o);
                    }
                });
        }
    }
}
