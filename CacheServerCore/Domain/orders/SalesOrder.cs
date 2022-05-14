using CacheServerCore.Domain.crm;

namespace CacheServerCore.Domain.orders
{
    public class SalesOrder
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime SalesDate { get; set; }

        public void Deconstruct(out Customer customer, out DateTime salesDate)
        {
            customer = this.Customer;
            salesDate = this.SalesDate;
        }


    }
}
