namespace Application.Abstractions
{
    public interface IUoWFactory
    {
        IUoW Create();
    }
}
