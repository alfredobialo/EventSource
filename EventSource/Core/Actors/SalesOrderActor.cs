using System;
using Akka.Actor;
using Akka.Persistence;

namespace EventSource.Core.Actors
{
    public class SalesOrderActor :ReceiveActor
    {
        public SalesOrderActor()
        {
            Receive<BaseActorMessage>(HandleMessage);
        }


        void HandleMessage(BaseActorMessage message)
        {
            Context.System.Scheduler.ScheduleTellRepeatedly(TimeSpan.FromSeconds(2),TimeSpan.FromSeconds(4), this.Sender, message, Self );
        }
    }

    public class InventoryStockPersistableActor : PersistentActor
    {
        protected override bool ReceiveRecover(object message)
        {
            return false;
        }

        protected override bool ReceiveCommand(object message)
        {
            return false;
        }

        public override string PersistenceId { get; }
    }
}
