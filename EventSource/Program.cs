using System;
using System.Collections.Immutable;
using EventSource.Core;
using EventSource.Domain.crm;
using EventSource.Domain.orders;
using EventSource.Services.orders;

namespace EventSource
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sales Management App!");
            ISalesOrderService salesOrderService = new SalesOrderService();
            SalesOrder so = new SalesOrder()
            {
                Customer = new Customer()
                {
                    Id = "alfred-obialo",
                    Name = "Alfred Obialo"
                },
                Id ="000123",
                SalesDate = DateTime.Now,
                ChannelId = "HQ-001"
            };

            salesOrderService.SalesOrderCreated += SalesOrderServiceOnSalesOrderCreated;
            salesOrderService.BeforeSalesOrderCreated += SalesOrderServiceOnBeforeSalesOrderCreated;

            salesOrderService.CreateOrder(so).GetAwaiter().GetResult();
            Console.ReadLine();
        }

        private static void SalesOrderServiceOnBeforeSalesOrderCreated(object sender, SalesOrderCreatingEventArg eventarg)
        {
            Console.WriteLine("Before Sales Order Created Event Is Called");
            Console.WriteLine($"Is Sales Order Valid? {(eventarg.IsValid ? "Yes" : "NO")}");
        }

        private static void SalesOrderServiceOnSalesOrderCreated(object sender, CommandResultEventArg eventargs)
        {
            // We have successfully Created a new Sales Order
            // Send Message to Broker: (Kafka) etc
            var (result, data) = (eventargs.Result, eventargs.DataInfo);
            Console.WriteLine(result.Message);
            Console.WriteLine(data.Id);

            if (data.Data is SalesOrder salesOrder)
            {
                var (customer, date) = salesOrder;
                Console.WriteLine("===========DECONTRUCTOR===========");
                Console.WriteLine($"===========  {customer.Id}  ===========");
                Console.WriteLine($"===========  {date:d}  ===========");
                Console.WriteLine("===========END OF DECONTRUCTOR===========");
                Console.WriteLine("Sales Order Details:");
                Console.WriteLine($"Customer Name: {salesOrder.Customer.Name}");
                Console.WriteLine($"Date: {salesOrder.SalesDate:f}");
            }

        }
    }
}
