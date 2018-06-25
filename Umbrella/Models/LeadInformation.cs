using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Data;
using Umbrella.Helpers;
using Umbrella.Models;
using static Umbrella.Models.LeadsCollection;

namespace Umbrella.Models
{
    public class LeadsCollection : ObservableCollection<LeadInformation>
    {
        public async Task AddAsync(LeadInformation leads)
        {

            var favorite = new Lead()
            {
                EnquiryId = leads.EnquiryId,
                ContactId = leads.ContactId,
                //Name = leads.Name,
                Business = leads.Business,
                Email = leads.Email,
                Mobile = leads.Mobile,
                Home = leads.Home,
                Office = leads.Office,
                Source = leads.Source,
                Category = leads.Category,
                Status = leads.Status,
                Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.",
                Created = leads.Created,
            };
           // await LeadsManager.DefaultManager.SaveFavoriteAsync(favorite);

            this.Add(leads);
        }
        public class LeadInformation : ObservableBase
        {
            private string _EnquiryId;


            public string EnquiryId { get { return this._EnquiryId; } set { this.SetProperty(ref this._EnquiryId, value); } }


            private string _ContactId;

            public string ContactId { get { return this._ContactId; } set { this.SetProperty(ref this._ContactId, value); } }

            private string _Name;

            public string Name { get { return this._Name; } set { this.SetProperty(ref this._Name, value); } }

            private string _Business;

            public string Business { get { return this._Business; } set { this.SetProperty(ref this._Business, value); } }

            private string _Email;

            public string Email { get { return this._Email; } set { this.SetProperty(ref this._Email, value); } }

            private string _Mobile;

            public string Mobile { get { return this._Mobile; } set { this.SetProperty(ref this._Mobile, value); } }

            private string _Home;

            public string Home { get { return this._Home; } set { this.SetProperty(ref this._Home, value); } }

            private string _Office;

            public string Office { get { return this._Office; } set { this.SetProperty(ref this._Office, value); } }


            private string _Source;
            public string Source { get { return this._Source; } set { this.SetProperty(ref this._Source, value); } }

            private string _Category;
            public string Category { get { return this._Category; } set { this.SetProperty(ref this._Category, value); } }

            private string _Status;
            public string Status { get { return this._Status; } set { this.SetProperty(ref this._Status, value); } }

            private string _Enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin non imperdiet mauris. Ut in arcu nec ipsum vulputate volutpat.";
            public string Enquiry { get { return this._Enquiry; } set { this.SetProperty(ref this._Enquiry, value); } }

            private DateTime _Created;
            public DateTime Created { get { return this._Created; } set { this.SetProperty(ref this._Created, value); } }


        }
    }
}