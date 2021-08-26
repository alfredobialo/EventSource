using System.Threading.Tasks;
using EventSource.Domain.orders;

namespace EventSource.Services.orders
{
    public interface ISalesOrderService
    {
        event SalesOrderCreating BeforeSalesOrderCreated;
        event SalesOrderCreated SalesOrderCreated;
        Task CreateOrder(SalesOrder order);
    }
}