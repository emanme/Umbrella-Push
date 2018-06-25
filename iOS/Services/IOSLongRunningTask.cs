using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;
using Xamarin.Forms;

namespace Umbrella.iOS.Services
{
    public class IOSLongRunningTask
    {   
        nint _taskId;
        CancellationTokenSource _cts;

        public void Start()
        {
            _cts = new CancellationTokenSource();

            _taskId = UIApplication.SharedApplication.BeginBackgroundTask("LongRunningTask", OnExpiration);

            //on progress
            var counter = new TaskCounter();
            counter.RunCounter("1");
            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        void OnExpiration()
        {
            _cts.Cancel();
        }
    }
}
