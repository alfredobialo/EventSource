using EventSource.Core;

namespace EventSource.Domain.orders
{
    public delegate void SalesOrderCreated(object sender, CommandResultEventArg eventArgs);
}