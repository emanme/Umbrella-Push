using System.Collections.Generic;
using Umbrella.Models;
using Umbrella.Views;

namespace Umbrella.Services
{
    public class SettingsService
    {
        public List<SettingsItem> GetSettingsItems()
        {
            var list = new List<SettingsItem>();

            list.Add(new SettingsItem
            {
                Icon = "notifications_icon_green",
                Title = "Notifications",
                Description = "Set Umbrella app notification settings",
                Target = typeof(NotificationsPage)
            });

            list.Add(new SettingsItem
            {
                Icon = "terms_and_conditions_icon_green",
                Title = "Terms & Conditions",
                Description = "Read Umbrella app's Terms & Conditions",
                Target = typeof(TermsAndConditionsPage)
            });

            list.Add(new SettingsItem
            {
                Icon = "privacy_policy_icon_green",
                Title = "Privacy Policy",
                Description = "Read Umbrella app's Privacy Policy",
                Target = typeof(PrivacyPolicyPage)
            });

            list.Add(new SettingsItem
            {
                Icon = "contact_us_icon_green",
                Title = "Contact Us",
                Description = "Contact Umbrella Business Support",
                Target = typeof(ContactUsPage)
            });

            list.Add(new SettingsItem
            {
                Icon = "logout_icon_green",
                Title = "Logout",
                Description = "Logout current user and clear cache",
                Target = null
            });

            return list;
        }
    }
}
