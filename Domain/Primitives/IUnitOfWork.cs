namespace Domain.Primitives;

public public interface IUnidOfWork
{
    Task<Int> SaveChangeAsync(CancellationToken cancellationToken =  default)
}