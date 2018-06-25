using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;

namespace Umbrella.Interfaces
{
    public interface ITopupPaymentService
    {
       Task<Dictionary<bool,string>> ProcessCustomerCard(Models.Card card, int amount, string email);
       Task<Dictionary<bool, string>> ProcessExistingCard(int amount, string email, RetrievedCard card);
       Task<List<RetrievedCard>> GetAllCurrentCards(string email);
    }
}
