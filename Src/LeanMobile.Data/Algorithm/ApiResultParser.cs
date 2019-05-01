using System;
using System.Collections.Generic;
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

            // TODO: Delete data when provided over API
            SetDummyData(result);

            var holdings = response.LiveResults?.Results?.Holdings;
            if (holdings != null)
            {
                ProcessHoldings(result, holdings);
            }

            var runtimeStatistics = response.LiveResults?.Results?.RuntimeStatistics;
            if (runtimeStatistics != null)
            {
                ProcessRuntimeStatistics(runtimeStatistics, result);
            }

            var statistics = response.LiveResults?.Results?.Statistics;
            if (statistics != null)
            {
                ProcessStatistics(statistics, result);
            }

            var profitLoss = response.LiveResults?.Results?.ProfitLoss;
            if (profitLoss != null)
            {
                ProcessProfitLoss(profitLoss, result);
            }

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
        
        private void ProcessOrders(AlgorithmResult result, IList<Order> orders)
        {
            result.Orders = new Orders
            {
                DateUpdated = DateTime.UtcNow
            };

            foreach (var order in orders)
            {
                try
                {
                    var newOrder = new LeanMobile.Algorithms.Results.Order
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

        private void ProcessHoldings(AlgorithmResult result, IDictionary<string, Holding> holdings)
        {
        }

        private void SetDummyData(AlgorithmResult result)
        {
            result.Statistics = new Statistics
            {
                Equity = 10000,
                Unrealized = -83.34m,
                Holdings = 30000
            };
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

        private void ProcessRuntimeStatistics(IDictionary<string, string> runtimeStatistics, AlgorithmResult result)
        {
            // TODO: Implement this as soon as QuantConnect provides this data over the API
        }

        private void ProcessStatistics(IDictionary<string, string> statistics, AlgorithmResult result)
        {
            // TODO: Implement this as soon as QuantConnect provides this data over the API
            result.Statistics = new Statistics
            {
                Unrealized = 34,
                Equity = 10000
            };
        }

        private void ProcessProfitLoss(IDictionary<DateTime, decimal> profitLoss, AlgorithmResult result)
        {
            // TODO: Implement this as soon as QuantConnect provides this data over the API
        }

        private void ProcessLogResult(AlgorithmResult result, LiveLogResponse response)
        {
            response.EnsureSuccess();

            result.Log = new Log
            {
                DateUpdated = DateTime.UtcNow,
                Items = response.Logs
            };
        }
    }
}