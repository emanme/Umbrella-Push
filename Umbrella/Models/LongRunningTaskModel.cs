using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbrella.Models
{
    public class LongRunningTaskModel
    {

    }
    public class TickedMessages
    {
        public string Message { get; set; }
    }
    public class StartLongRunningTaskMessage { }

    public class StopLongRunningTaskMessage { }
    public class CancelledMessage { }
    public class TickedListMessages
    {
        public string Message { get; set; }
    }
    public class StartCustomerMessage { }
    public class StopCustomerMessage { }
}
