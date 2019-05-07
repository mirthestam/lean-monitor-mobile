using System;
using System.Collections.Generic;
using System.Linq;
using LeanMobile.Algorithms.Results;
using LeanMobile.Data.Model;
using LeanMobile.Data.Model.Responses;
using LeanMobile.Data.Utils;
using NodaTime;
using Chart = LeanMobile.Data.Model.Chart;

namespace LeanMobile.Data.Algorithm
{
    public class ApiResultParser : IApiResultParser
    {
        public void ProcessLiveResult(AlgorithmResult result, LiveAlgorithmResultsResponse response)
        {
            response.EnsureSuccess();

            if (response.LiveResults.Resolution != Resolution.Second)
            {
                // TODO: Confirm whether resolution is always second.
                // I tried multiple live algorithms, subscribing to minute and daily data. Resolution
                // always appears to be in seconds.
                throw new Exception($"Unexpected resolution: {response.LiveResults.Resolution}");
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

            var charts = response.LiveResults?.Results?.Charts;
            if (charts != null)
            {
                ProcessCharts(result, charts);
            }
        }

        private void ProcessCharts(AlgorithmResult result, IDictionary<string, Model.Chart> charts)
        {
            if (!charts.TryGetValue("Strategy Equity", out var sourceChart)) return;
            if (!sourceChart.Series.TryGetValue("Equity", out var sourceSeries)) return;

            var convertedSeries = sourceSeries.Values.Select(v => new Algorithms.Results.ChartPoint
            {
                X = Instant.FromUnixTimeSeconds(v.X),
                Y = v.Y
            });

            if (result.EquityChart == null)
            {
                result.EquityChart = new List<ChartPoint>();
            }

            result.EquityChart.Clear();
            result.EquityChart.AddRange(convertedSeries);
        }

        private static void ProcessOrders(AlgorithmResult result, ICollection<Model.Order> orders)
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