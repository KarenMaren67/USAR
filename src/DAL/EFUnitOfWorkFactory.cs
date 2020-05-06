using Application.Abstractions;

namespace DAL
{
    public class EFUnitOfWorkFactory : IUoWFactory
    {
       public IUoW Create() => new EFUnitOfWork();
    }
}
