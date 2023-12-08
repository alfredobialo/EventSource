using System;
using System.Collections.Generic;
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
            Solution(new int[1]);
            Console.ReadLine();
            //PipeStream ps = new NamedPipeServerStream("myPipe", PipeDirection.InOut);
            bool exitApp = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========   ESTHER MULTIPLICATION CALCULATOR  ========");
            Console.WriteLine();

            while (!exitApp)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Please enter First number here >");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Please enter Second number here >");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("Please enter Third number here >");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine();
                int xyz = x * y * z;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Result of {x} x {y} x {z} = {xyz:N0}");

                Console.Write("Do you want to Perform another calculation? Enter 1 for Yes > ");
                exitApp = Console.ReadLine() == "0" ? true : false;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("PUMKIN APP has ENDED. Thanks for Shinning us");
            Console.ResetColor();
            Console.ReadLine();
            ISalesOrderService salesOrderService = new SalesOrderService();
            SalesOrder so = new SalesOrder()
            {
                Customer = new Customer()
                {
                    Id = "alfred-obialo",
                    Name = "Alfred Obialo"
                },
                Id = "000123",
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
        
        /*def solution(arr):
          arr.sort(key=lambda arr: (bin(arr).count("1"), arr))
          return arr
        
        nums = [31,15,7,3,2]
        print(solution(nums))*/

        public static void Solution(int[] arr)
        {
            int[] nums  = new int[]{1,2,3,4};
            var lst = new List<string>();
            foreach (var num in nums)
            {
                lst.Add(Convert.ToString(num,2));
                //lst.Add(BinaryConversion.ConvertBase10ToBaseN(num,2));
            }

            print(lst);
        }

        private static void print(List<string> lst)
        {
            foreach (var i in lst)
            {
                Console.WriteLine(i);
            }
        }
    }
}
