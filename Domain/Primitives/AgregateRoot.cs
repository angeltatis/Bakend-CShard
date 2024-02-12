namespace Domain.Primitives;

public abstract class AgregateRoot {

    private readonly List<DomainEvent> _domainEvent =  new();

    public ICollection<DomainEvebt> GetDomainEvent() => _domainEvent;

    public void Raise(DomainEvent domainEvent)
    {
        _domainEvent.Add(domainEvent);
    }
}