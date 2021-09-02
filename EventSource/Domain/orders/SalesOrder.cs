using System;
using EventSource.Services.crm;

namespace EventSource.Domain.orders
{
    public class SalesOrder : BaseEntity
    {
        public ICustomer Customer { get; set; }
        public DateTime SalesDate { get; set; }

        public void Deconstruct(out ICustomer customer, out DateTime salesDate)
        {
            customer = this.Customer;
            salesDate = this.SalesDate;
        }


    }
}
