using System;
using System.Collections.Generic;

namespace EventSource.Domain.orders
{
    public class SalesOrderCreatingEventArg : EventArgs
    {
        public SalesOrderCreatingEventArg(SalesOrder salesOrderInfo, bool isValid,
            IReadOnlyCollection<string> validationErrors)
        {
            SalesOrderInfo = salesOrderInfo;
            IsValid = isValid;
            ValidationErrors = validationErrors;
        }

        public SalesOrder SalesOrderInfo { get; private set; }
        public IReadOnlyCollection<String> ValidationErrors { get; private set; }
        public bool IsValid { get; private set; }
    }
}