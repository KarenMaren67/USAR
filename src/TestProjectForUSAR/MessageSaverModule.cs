using Prism.Ioc;
using Prism.Modularity;
using TestProjectForUSAR.Views.Main.Message;

namespace TestProjectForUSAR
{
    public class MessageSaverModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MessageView>();
        }
    }
}
