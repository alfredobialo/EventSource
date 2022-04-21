using System;
using EventSource.Core;
using EventSource.Domain.crm;
using EventSource.Domain.orders;
using EventSource.Services.orders;
using System.IO.Pipes;


namespace EventSource.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeStream ps = new NamedPipeServerStream("myPipe", PipeDirection.InOut);


            Console.WriteLine("Hello World!");
            ISalesOrderService salesOrderService = new SalesOrderService();
            SalesOrder so = new SalesOrder()
            {
                Customer = new Customer()
                {
                    Id = "alfred-obialo",
                    Name = "Alfred Obialo"
                },
                Id ="000123",
                SalesDate = DateTime.Now
            };

            salesOrderService.SalesOrderCreated += SalesOrderServiceOnSalesOrderCreated;
            salesOrderService.BeforeSalesOrderCreated += SalesOrderServiceOnBeforeSalesOrderCreated;

            salesOrderService.CreateOrder(so);
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
               Console.WriteLine("Sales Order Details:");
               Console.WriteLine($"Customer Name: {salesOrder.Customer.Name}");
               Console.WriteLine($"Date: {salesOrder.SalesDate:f}");
           }

        }
    }
}
