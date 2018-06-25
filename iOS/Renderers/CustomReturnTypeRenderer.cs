using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Umbrella.Custom;
using Umbrella.Enums;
using Umbrella.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomReturnTypeEntry), typeof(CustomReturnTypeRenderer))]
namespace Umbrella.iOS.Renderers
{
    public class CustomReturnTypeRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            CustomReturnTypeEntry entry = (CustomReturnTypeEntry)this.Element;

            if (this.Control != null)
            {
                if (entry != null)
                {
                    SetReturnType(entry);

                    Control.ShouldReturn += (UITextField tf) =>
                    {
                        entry.InvokeCompleted();
                        return true;
                    };
                }
            }
        }

        private void SetReturnType(CustomReturnTypeEntry entry)
        {
            ReturnType type = entry.ReturnType;

            switch (type)
            {
                case ReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case ReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case ReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case ReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case ReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }
    }
}
