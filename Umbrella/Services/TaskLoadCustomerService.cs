using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbrella.Models;
using Xamarin.Forms;

namespace Umbrella.Services
{
    public class TaskLoadCustomerService
    {
        public async Task MethodRunPeriodically(CancellationToken token)
        {
            long num = 5;
            await Task.Run(async () => {
               for (long i = 5; i >= 0; i--)
               {
                   token.ThrowIfCancellationRequested();
                   num = i;
                   await Task.Delay(1000);
                   var message = new TickedListMessages
                   {
                       Message = i.ToString()
                   };
                   Device.BeginInvokeOnMainThread(() => {
                       MessagingCenter.Send<TickedListMessages>(message, "TickedListMessages");
                   });
               }
                if(num == 0){
                    var msgStop = new StopCustomerMessage();
                    MessagingCenter.Send(msgStop, "StopCustomerMessage");
                }
           }, token);

        }
    }
}
