using EventSource.Services.crm;

namespace EventSource.Domain.crm
{
    public class Customer : BaseEntity, ICustomer
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}