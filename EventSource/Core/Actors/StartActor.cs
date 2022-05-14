using Akka.Actor;

namespace EventSource.Core.Actors
{
    public class StartActor
    {
        public static void CreateActorSystem()
        {
            var actorSystem = ActorSystem.Create("orderManagement");
            var salesActor = actorSystem.ActorOf(Props.Create<SalesOrderActor>());
            salesActor.Tell(new BaseActorMessage()
            {
                GroupId = "Group ABC",
                Id = "0001"
            });
        }
    }
}
