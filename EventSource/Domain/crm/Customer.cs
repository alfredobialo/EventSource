﻿using EventSource.Services.crm;

namespace EventSource.Domain.crm
{
    public class Customer : BaseEntity, ICustomer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public AddressInfo ContactAddress { get; set; }
    }

    public class AddressInfo
    {
        public string  City { get; set; }
        public string Province { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
