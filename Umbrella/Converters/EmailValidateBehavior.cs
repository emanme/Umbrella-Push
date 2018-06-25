using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Umbrella.Converters
{
    public class EmailValidateBehavior : Behavior<Custom.CustomReturnTypeEntry>
    {
        protected override void OnAttachedTo(Custom.CustomReturnTypeEntry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Custom.CustomReturnTypeEntry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!string.IsNullOrEmpty(args.NewTextValue))
            {
                bool isValid = EmailRegex.IsMatch(args.NewTextValue);
                ((Custom.CustomReturnTypeEntry)sender).TextColor = isValid ? Color.Default : Color.Red;
            }

        }
    }
}
