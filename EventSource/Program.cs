using System;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text;
using EventSource.Core;
using EventSource.Core.Actors;
using EventSource.Domain.crm;
using EventSource.Domain.orders;
using EventSource.Services.orders;
using Newtonsoft.Json;

namespace EventSource
{
    class Program
    {
        static void Main(string[] args)
        {
            string _generateHashFor(object o)
            {
                if (o == null) throw new ArgumentException("Generate Hash for null object not allowed");
                var serializedObj = JsonConvert.SerializeObject(o);
                var base64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serializedObj));
                Console.WriteLine($"Base64 {base64}");
                Console.WriteLine($"Serialize String {serializedObj}");

                return _createMD5Hash(base64);
            }

            string _createMD5Hash(string input)
            {
                // Step 1, calculate MD5 hash from input
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }

            var obj = new
            {
                name = "Alfred Obialo",
                age = 36,
                dateOfHire = DateTime.Now.AddYears(-2)
            };
            SalesOrder so = new SalesOrder()
            {
                Customer = new Customer()
                {
                    Id = "alfred-obialo",
                    Name = "Alfred Obialo",
                    ChannelId = "99210NN022",
                    ContactAddress = new AddressInfo()
                    {
                        City = "Ajah",
                        Province = "Ado Road",
                        State = "Lagos",
                        ZipCode = "001"
                    }
                },
                Id = "000123",
                SalesDate = new DateTime(2021, 12, 16),
                ChannelId = "HQ-001"
            };
            var hash = _generateHashFor(so);
            Console.WriteLine($"hash is {hash}");
            Console.ReadLine();
            Console.WriteLine("Sales Management App!");
            StartActor.CreateActorSystem();
            ISalesOrderService salesOrderService = new SalesOrderService();


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

    class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Course
    {
        public string Code { get; set; }
    }
}
