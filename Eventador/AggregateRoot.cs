using System;
using System.ComponentModel.DataAnnotations;

namespace Eventador
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }

    public class AggregateRoot : IAggregateRoot
    {
        [Key]
        public Guid Id { get; protected set; }
    }
}
