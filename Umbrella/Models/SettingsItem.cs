using System;

namespace Umbrella.Models
{
    public class SettingsItem
    {
        public string Icon { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Type Target { get; set; }
    }
}
