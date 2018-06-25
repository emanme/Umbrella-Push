using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;

namespace Umbrella.ViewModels
{
    public class CalendarEventsViewModel : INotifyPropertyChanged
    {
        private List<CalendarEvent> _calendarEvents;

        public List<CalendarEvent> CalendarEventsWeek
        {
            get { return _calendarEvents; }
            set
            {
                if (_calendarEvents != value)
                {
                    _calendarEvents = value;
                    NotifyPropertyChanged("CalendarEventsWeek");
                }
            }
        }

        public CalendarEventsViewModel()
        {
            var service = new CalendarEventsService();
            _calendarEvents = service.GetCalendarApiWeek();
            Global.SetCalendarListWeek(_calendarEvents);
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
