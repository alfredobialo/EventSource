using System;
using EventSource.Services.crm;

namespace EventSource.Domain.orders
{
    public class SalesOrder : BaseEntity
    {
        public ICustomer Customer { get; set; }
        public DateTime SalesDate { get; set; }
    }
}