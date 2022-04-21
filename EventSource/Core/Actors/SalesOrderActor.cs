using System;
using Akka.Actor;

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
}
