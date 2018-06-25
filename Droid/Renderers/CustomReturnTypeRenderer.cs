﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Umbrella.Custom;
using Xamarin.Forms;
using Umbrella.Enums;
using Android.Views.InputMethods;
using Umbrella.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomReturnTypeEntry), typeof(CustomReturnTypeRenderer))]
namespace Umbrella.Droid.Renderers
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

                    // Editor Action is called when the return button is pressed
                    Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                    {
                        if (entry.ReturnType != ReturnType.Next)
                            entry.Unfocus();

                        // Call all the methods attached to base_entry event handler Completed
                        entry.InvokeCompleted();
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
                    Control.ImeOptions = ImeAction.Go;
                    Control.SetImeActionLabel("Go", ImeAction.Go);
                    break;
                case ReturnType.Next:
                    Control.ImeOptions = ImeAction.Next;
                    Control.SetImeActionLabel("Next", ImeAction.Next);
                    break;
                case ReturnType.Send:
                    Control.ImeOptions = ImeAction.Send;
                    Control.SetImeActionLabel("Send", ImeAction.Send);
                    break;
                case ReturnType.Search:
                    Control.ImeOptions = ImeAction.Search;
                    Control.SetImeActionLabel("Search", ImeAction.Search);
                    break;
                default:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;
            }
        }
    }
}