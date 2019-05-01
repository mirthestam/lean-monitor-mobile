using LeanMobile.Algorithms.Results;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace LeanMobile.Client.ViewModel.LiveAlgorithm.Dashboard
{
    public class OpenOrdersPanelViewModel : BindableBase
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        public OpenOrdersPanelViewModel(IObservable<AlgorithmResult> algorithmResults)
        {
            algorithmResults
                .Select(r => r.Orders.Items)
                .Subscribe(o =>
                {
                    var seenOrders = new List<int>();

                    foreach (var order in o)
                    {
                        // todo: update existing order
                        // or add if new
                        seenOrders.Add(order.Id);
                    }

                    // Build a list of orders to remove
                    // loop over the list, and remove the order

                });
            }
    }
}


