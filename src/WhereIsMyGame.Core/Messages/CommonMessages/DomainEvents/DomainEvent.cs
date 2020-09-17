using System;

namespace WhereIsMyGame.Core.Messages.CommonMessages.Domainevents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

    }
}
