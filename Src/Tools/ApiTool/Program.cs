using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ApiTool
{
    public static class Program
    {
        private static void Main()
        {
            var tool = new Tool();
            tool.Run().Wait();
        }
    }
}
