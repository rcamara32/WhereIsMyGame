using MediatR;
using System;

namespace WhereIsMyGame.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        
        public int Id { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }


    }
}
