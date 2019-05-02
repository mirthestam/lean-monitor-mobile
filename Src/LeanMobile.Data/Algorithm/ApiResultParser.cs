using System;
using System.Collections.Generic;
using System.Linq;
using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Model;
using LeanMobile.Data.Model.Responses;
using LeanMobile.Data.Utils;
using Order = LeanMobile.Data.Model.Order;

namespace LeanMobile.Data.Algorithm
{
    public class ApiResultParser : IApiResultParser
    {
        public void ProcessLiveResult(AlgorithmResult result, LiveAlgorithmResultsResponse response)
        {
            response.EnsureSuccess();

            var serverStatistics = response.LiveResults?.Results?.ServerStatistics;
            if (serverStatistics != null)
            {
                ProcessServerStatistics(result, serverStatistics);
            }

            var orders = response.LiveResults?.Results?.Orders;
            if (orders != null)
            {
                ProcessOrders(result, orders);
            }
            else
            {
                // Order information is missing
            }
        }
        
        private static void ProcessOrders(AlgorithmResult result, ICollection<Order> orders)
        {
            if (orders.Count == 0) return;

            if (result.Orders == null)
            {
                result.Orders = new Orders();
            }

            result.Orders.Updated();

            foreach (var order in orders)
            {
                try
                {
                    var newOrder = new Algorithms.Results.Order
                    {
                        DateTime = order.Time,
                        Id = order.Id,
                        Quantity = order.Quantity,
                        OrderType = (Algorithms.Results.OrderType)order.Type,
                        Status = (Algorithms.Results.OrderStatus)order.Status,
                        Symbol = order.Symbol?.Value
                    };

                    result.Orders.Items.Add(newOrder);
                }
                catch (Exception)
                {
                    
                }
            }
        }
       
        private static void ProcessServerStatistics(AlgorithmResult result, IDictionary<string, string> serverStatistics)
        {
            // TODO: Implement this as soon as QuantConnect provides this data over the API
            result.ServerStatistics = new ServerStatistics
            {
                DateUpdated = DateTime.UtcNow
            };

            if (serverStatistics.TryGetValue("CpuUsage", out string statistic))
            {
                // TODO: Parse the statistic
                result.ServerStatistics.CpuUsage = 50;
            }

            if (serverStatistics.TryGetValue("Uptime", out statistic))
            {
                // TODO: Parse the statistic
                result.ServerStatistics.Uptime = new TimeSpan();
            }

            if (serverStatistics.TryGetValue("MemoryUsed", out statistic))
            {
                // TODO: Parse the statistic
                result.ServerStatistics.MemoryUsed = 128;
            }

            if (serverStatistics.TryGetValue("MemoryTotal", out statistic))
            {
                // TODO: Parse the statistic
                result.ServerStatistics.MemoryTotal = 512;
            }
        }
    }
}