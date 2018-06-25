﻿using System.Collections.Generic;
using System.ComponentModel;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Helpers;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using Umbrella.Data;

namespace Umbrella.ViewModels
{
    public class CustomersPage : ObservableBase
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

        public CustomersPage()
        {
            var leadscategory = "leads";
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
            var leadscategory = "customers";
            Task.Factory.StartNew(() => methodRunPeriodically(leadscategory));
            //  Task.Run(async () =>await RefreshLeadsAsync());  
        }
        bool shouldRun = true;
        async Task methodRunPeriodically(string leadscategory)
        {
            //  while (shouldRun)
            //{

            var Leadlist = new List<Lead>();
            var leads = await App.LeadsDatabase.GetItemsAsync();
            //  System.Diagnostics.Debug.WriteLine("## leads.type() " + leads.GetType());
            System.Diagnostics.Debug.WriteLine("##2 leads.Count() " + leadscategory + " " + leads.Count());
            // System.Diagnostics.Debug.WriteLine("## ToString.Count() " + leads.ToString());
            //leads.ForEach(Print);
            foreach (var leadz in leads)
            {
                if (leadscategory == leadz.Category)
                {
                    Leadlist.Add(leadz);
                    System.Diagnostics.Debug.WriteLine("#leadz " + leadz.Name);
                }
                // leadz.Category
                // Leadlist.Add(leadz);
                //System.Diagnostics.Debug.WriteLine("x RefreshLeadsAsync " + leadz.Name);
            }
            // App.LeadsViewModel.Leads = Leadlist; 
            this.SetProperty(ref this._leads, Leadlist);
            //      await Task.Delay(5000); //Run this every 5 seconds
            //}
        }

        public async Task RefreshLeadsAsync()
        {
            var Leadlist = new List<Lead>();
            var leads = await App.LeadsDatabase.GetItemsAsync();
            //  System.Diagnostics.Debug.WriteLine("## leads.type() " + leads.GetType());
            System.Diagnostics.Debug.WriteLine("##1 leads.Count() " + leads.Count());
            // System.Diagnostics.Debug.WriteLine("## ToString.Count() " + leads.ToString());
            //leads.ForEach(Print);
            foreach (var leadz in leads)
            {
                Leadlist.Add(leadz);
                //System.Diagnostics.Debug.WriteLine("x RefreshLeadsAsync " + leadz.Name);
            }

            this.SetProperty(ref this._leads, Leadlist);
        }
        private void Convert()
        {

        }

        public async Task setdAsync()
        {
            var l = await App.LeadsDatabase.GetItemsAsync();
            var ll = new List<Lead>();
            foreach (Lead o in l)
            {
                System.Diagnostics.Debug.WriteLine("x list " + o.Name);
                ll.Add(o);
            }
            this.SetProperty(ref this._leads, ll);
        }
        public async void setData()
        {

            APIHelper2 a = new APIHelper2();

            var res = await a.GetLead();

            var list = res.ToList();
            var l = new List<Lead>();
            System.Diagnostics.Debug.WriteLine("SaveLeadsAsync list");
            foreach (var o in list)
            {

                l.Add(o);
                System.Diagnostics.Debug.WriteLine("o list " + o.Name);
            }
            //  App.LeadsDatabase.ResetLeads();
            App.LeadsDatabase.SaveLeadsAsync(l);

            this.SetProperty(ref this._leads, list);

        }
    }
}