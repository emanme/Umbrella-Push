using System.Collections.Generic;
using Umbrella.Models;
using Umbrella.Helpers;
using System.Threading.Tasks;
using System.Linq;
using Umbrella.Utilities;
using Plugin.Connectivity;

namespace Umbrella.ViewModels
{
    public class LeadsViewModel : ObservableBase
    {

        private List<Lead> _leads;

        public List<Lead> Leads
        {
            get { return _leads; }
            set
            {
                if (_leads != value)
                {
                    // _leads = value;
                    this.SetProperty(ref this._leads, value);
                }
            }
        }

        public LeadsViewModel()
        {
            var leadscategory = "";
          Task.Factory.StartNew(() => methodRunPeriodically(leadscategory));
          //  Task.Run(async () =>await RefreshLeadsAsync());  
        }
        public void ShowLeads(string leadscategory)
        {
             
            Task.Factory.StartNew(() => methodRunPeriodically(leadscategory));
            //  Task.Run(async () =>await RefreshLeadsAsync());  
        }
        public void ShowCustomers()
        {
            var leadscategory = "";
            Task.Factory.StartNew(() => methodRunPeriodically(leadscategory));
            //  Task.Run(async () =>await RefreshLeadsAsync());  
        }
        bool shouldRun = true;
        async Task methodRunPeriodically(string leadscategory)
        {
            var leads = await App.LeadsDatabase.GetItemsAsync();             leads = leads.Where(l => l.Category == leadscategory).ToList();             this.SetProperty(ref this._leads, leads); 
        }

        public async Task RefreshLeadsAsync(){
            var Leadlist = new List<Lead>();
            var leads = await App.LeadsDatabase.GetItemsAsync();
          //  System.Diagnostics.Debug.WriteLine("## leads.type() " + leads.GetType());
            System.Diagnostics.Debug.WriteLine("##1 leads.Count() " + leads.Count());
           // System.Diagnostics.Debug.WriteLine("## ToString.Count() " + leads.ToString());
            //leads.ForEach(Print);
            foreach( var leadz in leads){
                Leadlist.Add(leadz);
                //System.Diagnostics.Debug.WriteLine("x RefreshLeadsAsync " + leadz.Name);
            }
           
            this.SetProperty(ref this._leads,Leadlist);
        }
        private void Convert(){
            
        }
       
        public async Task setdAsync()
        {
            var l = await App.LeadsDatabase.GetItemsAsync();
            var ll= new List<Lead>();
            foreach (Lead o in l)
            {
                System.Diagnostics.Debug.WriteLine("x list " + o.Name);
                ll.Add(o);
            }
            this.SetProperty(ref this._leads, ll);
        }
        public void setData()
        {
            APIHelper2 a = new APIHelper2();
            var reward = a.GetReward();
           // var topCom = a.GetTopComrades();
            var topRec = a.GetTopRecruits();
            //var topResou = a.GetTopResources();
           // Global.SetTopCom(topCom);
            Global.SetTopRec(topRec);
            //Global.SetTopReso(topResou);
            Global.SetrewardPoints(reward.Number);
            Global.SetRankTitle(reward.Title);
            var res = a.GetLead();
            Loyalty loyalty = a.GetLoyalty();
            Global.SetLoyalty(loyalty);
            var medals = a.GetMedals();
            Global.SetMedalList(medals);
            App.LeadsDatabase.SaveLeadsAsync(res);
            this.SetProperty(ref this._leads, res);

        }
    }
}
