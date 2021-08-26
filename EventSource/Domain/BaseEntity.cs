using System;

namespace EventSource.Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        protected DateTime DateCreated { get; set; }
        protected string CreatedBy { get; set; }
        protected bool IsActive { get; set; } = true;
    }
}