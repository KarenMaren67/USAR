using Domain;
namespace Application.Abstractions
{
    public interface IFindLastService<T> : IService<T>
        where T : StorageEntity
    {
        T GetLast();
    }
}
