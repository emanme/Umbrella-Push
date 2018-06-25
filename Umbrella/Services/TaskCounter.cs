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
    public class TaskCounter
    {
        public void RunCounter(string countBadge)
        {
            var message = new TickedMessages
            {
                Message = countBadge
            };
            MessagingCenter.Send<TickedMessages>(message, "TickedMessages");
        }
    }
}
