using System.Collections.Generic;
using System.Threading.Tasks;
using EventSource.Core;
using EventSource.Domain.orders;

namespace EventSource.Services.orders
{
    public class SalesOrderService : ISalesOrderService
    {
        public event SalesOrderCreating BeforeSalesOrderCreated;
        public event SalesOrderCreated SalesOrderCreated;

        protected virtual void BeforeSalesOrderCreatedHandler(SalesOrder so, bool isValid,
            List<string> validationErrors)
        {
            if (this.BeforeSalesOrderCreated != null)
            {
                BeforeSalesOrderCreated(this, new SalesOrderCreatingEventArg(so, isValid, validationErrors));
            }
        }

        protected virtual void SalesOrderCreatedHandler(CommandResult result, CommandResultEventArg.CreatedDataInfo createdDataInfo)
        {
            if (this.SalesOrderCreated != null)
            {
                SalesOrderCreated(this, new CommandResultEventArg(result,createdDataInfo));
            }
        }

        public Task CreateOrder(SalesOrder order)
        {
            // SalesOrderValidator.validate(order);
            // raise an Event before and After a Sales Order is created
            bool isValidData = true;
            BeforeSalesOrderCreatedHandler(order, isValidData, new List<string>());
            if (isValidData)
            {
                // Persist the Data
                
                //After Event should be raised here
                SalesOrderCreated(this, new CommandResultEventArg(CommandResult.Successful(), new CommandResultEventArg.CreatedDataInfo()
                {
                    Data = order, DataType = "salesorder", Id = order.Id
                }));
            }
            
            return Task.CompletedTask;
        }
    }
}