using System.Collections.Generic;
using Umbrella.Models;

namespace Umbrella.Services
{
    public class NotificationsService
    {
        public List<NotificationsItem> GetNotificationsItems()
        {
            var list = new List<NotificationsItem>();

            list.Add(new NotificationsItem
            {
                Title = "General",
                Description = "General Notifications, Umbrella News, Balance Alerts etc",
                IsToggled = true,
                ToogleFor = "general"
            });

            list.Add(new NotificationsItem
            {
                Title = "Morale Booster",
                Description = "Receive inspirational quotes, tips and advice to keep your morale up and focused on the Mission. ",
                IsToggled = true,
                ToogleFor = "daily_motivation"
            });

            list.Add(new NotificationsItem
            {
                Title = "New Message",
                Description = "Receive a notification every time you receive a new message, mission or Top Secret Communication from Command",
                IsToggled = true,
                ToogleFor = "new_message"
            });

            list.Add(new NotificationsItem
            {
                Title = "Umbrella Status Radar",
                Description = "Early Warning system advising you when one of your Recruits or Comrades drops significantly in morale, enlists or deserts.",
                IsToggled = true,
                ToogleFor = "lead_converted"
            });
            list.Add(new NotificationsItem
            {
                Title = "Reminders",
                Description = "Receive a notification when a call back has been made, is coming up, changed or is cancelled.",
                IsToggled = true,
                ToogleFor = "call_back_reminders"

            });

            return list;
        }
    }
}
