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
using System.Net.Http;
using System.Reflection;

namespace Umbrella.Droid.Dependencies
{

    public static class StripeConfiguration
    {
        /// <summary>
        /// <para>This is the API version that Stripe.net will automatically use when working with Stripe. You only need to be concerned if you are using webhooks (Stripe Events) and having issues.</para>
        /// <para>If you notice webhooks are not working correctly, email Stripe and ask them to downgrade your API version to match the StripeApiVersion. Work is going on to catch up so this isn't necessary!</para>
        /// </summary>
        public static string StripeApiVersion = "2016-07-06";
        public static string StripeNetVersion { get; private set; }

        private static string _apiKey;
        internal static HttpMessageHandler HttpMessageHandler { get; private set; }

        static StripeConfiguration()
        {
            StripeNetVersion = new AssemblyName(typeof(Requestor).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
#if !PORTABLE
                _apiKey = Stripe.StripeClient.DefaultPublishableKey;
#endif
            }

            return _apiKey;
        }

        public static void SetHttpMessageHandler(HttpMessageHandler handler)
        {
            HttpMessageHandler = handler;
        }

        public static void SetApiKey(string newApiKey)
        {
            _apiKey = newApiKey;
        }
    }
}