using System;

namespace EventSource
{
    public class SalesOrder : BaseEntity
    {
        public ICustomer Customer { get; set; }
        public DateTime SalesDate { get; set; }
    }
}