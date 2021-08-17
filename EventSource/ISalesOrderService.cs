using System.Threading.Tasks;

namespace EventSource
{
    public interface ISalesOrderService
    {
        event SalesOrderCreating BeforeSalesOrderCreated;
        event SalesOrderCreated SalesOrderCreated;
        Task CreateOrder(SalesOrder order);
    }
}