using System;
using System.ComponentModel;
using Umbrella.Enums;
using Xamarin.Forms;
using System.Collections.Generic;
using Umbrella.Utilities;

namespace Umbrella.Models
{
    public class Message : INotifyPropertyChanged
    {
        public ImageSource Image { get; set; }

        public string Sender { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public MessageType Type { get; set; }

        public bool HasAttachment { get; set; }

        public DateTime Received { get; set; }

        private bool isUnread;
        public bool IsUnread
        {
            get { return isUnread; }
            set
            {
                if (isUnread != value)
                {
                    isUnread = value;
                    NotifyPropertyChanged("IsUnread");
                }
            }
        }
        private bool isRead;
        public bool Read
        {
            get { return isRead; }
            set
            {
                if (isRead != value)
                {
                    isRead = value;
                    NotifyPropertyChanged("Read");
                }
            }
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

    public class MessageList
    {       
        public string subject { get; set; }
        public string description { get; set; }
        public List<BodyList> replies { get; set; }
    }
    public class RootObjectReply
    {
        public List<BodyList> replies { get; set; }
    }
    public class BodyList
    {
        public string body { get; set; }
        public string body_text { get; set; }
        public string Ticket { get; set; }
        //public int id { get; set; }
        public bool incoming { get; set; }
        //public string user_id { get; set; }
        public string support_email { get; set; }
        public int source { get; set; }
        public int ticket_id { get; set; }
        public string[] to_emails { get; set; }
        public string from_email { get; set; }
        public string[] cc_emails { get; set; }
        public string[] bcc_emails { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string[] attachments { get; set; }
    }
 }
