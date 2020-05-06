using Application.Abstractions;
using Application.Extensions;
using Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace TestProjectForUSAR.Views.Main.Message
{
    public class MessageViewModel : BindableBase, INavigationAware
    {
        private readonly IFindLastService<MessageEntity> _messagesService;

        MessageViewModel(IFindLastService<MessageEntity> messagesService)
        {
            _messagesService = messagesService;
            SendCommand = new DelegateCommand<string>(OnSend);
        }

        public DelegateCommand<string> SendCommand { get; set; }

        public string CurrentMessageText { get; set; }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var message = _messagesService.GetLast();
            ComposeLastMessageInformation(message);

            RaisePropertyChanged("CurrentMessageText");
        }

        private void ComposeLastMessageInformation(MessageEntity message)
        {
            CurrentMessageText = message.Text;

            if (CurrentMessageText != string.Empty)
            {
                CurrentMessageText = $"{CurrentMessageText} \n {message.UserName} \n {message.Time.ToString()}";
            }
        }

        private void OnSend(string text)
        {
            if (text.HasContent())
            {
                _messagesService.Add(new MessageEntity
                {
                    Text = text,
                    Time = DateTime.Now,
                    UserName = Environment.UserName
                });

                CurrentMessageText = string.Empty;
                RaisePropertyChanged("CurrentMessageText");
            }
        }
    }
}
