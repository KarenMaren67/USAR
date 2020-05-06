using Application.Abstractions;
using Application.Services;
using Domain;
using Prism.Ioc;
using Prism.Modularity;

namespace Application
{
    public class AppModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFindLastService<MessageEntity>, MessagesService>();
        }
    }
}
