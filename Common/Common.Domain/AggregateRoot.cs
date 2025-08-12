using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class AggregateRoot:BaseEntity
    {
        private readonly List<BaseDomainEvent> _baseDomainEvents = new List<BaseDomainEvent>();
        [NotMapped]
        public List<BaseDomainEvent> baseDomains => _baseDomainEvents;

        public void AddDomainEvent(BaseDomainEvent baseDomain)
        {
            _baseDomainEvents.Add(baseDomain);
        }

        public void DeleteDomainEvent(BaseDomainEvent baseDomain)
        {
            _baseDomainEvents?.Remove(baseDomain);
        }
    }
}
