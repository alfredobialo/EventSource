namespace EventSource.Core.Actors
{
    public record BaseActorMessage
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
    }
}
