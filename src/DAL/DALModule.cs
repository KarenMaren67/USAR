using Application.Abstractions;
using Prism.Ioc;
using Prism.Modularity;

namespace DAL
{
    public class DALModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUoWFactory, EFUnitOfWorkFactory>();
        }
    }
}
