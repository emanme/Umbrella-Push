using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;
using Xamarin.Forms;
namespace Umbrella.ViewModels
{
    public class MessagesViewModel : INotifyPropertyChanged
    {
        private List<Message> _messages;

        public List<Message> Messages
        {
            get { return _messages; }
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                    NotifyPropertyChanged("Messages");
                }
            }
        }
        private List<Message> _topSecretTempoMessage;

        public List<Message> TopSecretTempoMessage
        {
            get { return _topSecretTempoMessage; }
            set
            {
                if (_topSecretTempoMessage != value)
                {
                    _topSecretTempoMessage = value;
                    NotifyPropertyChanged("TopSecretTempoMessage");
                }
            }
        }
        public MessagesViewModel()
        {           
            var service = new MessagesService();
            //_messages = service.GetAllMessages();
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
