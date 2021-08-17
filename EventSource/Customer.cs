namespace EventSource
{
    public class Customer : BaseEntity, ICustomer
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}