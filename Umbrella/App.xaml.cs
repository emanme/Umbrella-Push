
using Umbrella.Data;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.ViewModels;
using Umbrella.Views;
using Xamarin.Forms;
using Umbrella.Utilities;
using Plugin.Badge;
using System;

namespace Umbrella
{
    public partial class App : Application
    {
        public static bool IsNotified { get; set; }
        public static string AppName { get; set; }
        public static LeadsViewModel LeadsViewModel { get; set; }
        public static CustomersViewModel CustomersViewModel { get; set; }
        public static CallBacksViewModel CallBacksViewModel { get; set; }
        static LeadsDataBase leadsDatabase;
        public static LeadsDataBase LeadsDatabase
        {
            get
            {
                if (leadsDatabase == null)
                {
                    leadsDatabase = new LeadsDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Leads.db3"));
                }
                return leadsDatabase;
            }
        }
        static TargetsDatabase targetsDatabase;
        public static TargetsDatabase TargetsDatabase
        {
            get
            {
                if (targetsDatabase == null)
                {
                    targetsDatabase = new TargetsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Targets.db3"));
                }
                return targetsDatabase;
            }
        }


        static MedalDatabase medalDatabase;
        public static MedalDatabase MedalDatabase
        {
            get
            {
                if (medalDatabase == null)
                {
                    medalDatabase = new MedalDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Medals.db3"));
                }
                return medalDatabase;
            }
        }
        static RankDatabase rankDatabase;
        public static RankDatabase RankDatabase
        {
            get
            {
                if (rankDatabase == null)
                {
                    rankDatabase = new RankDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Rank.db3"));
                }
                return rankDatabase;
            }
        }
        static LoyaltyDatabase loyaltyDatabase;
        public static LoyaltyDatabase LoyaltyDatabase
        {
            get
            {
                if (loyaltyDatabase == null)
                {
                    loyaltyDatabase = new LoyaltyDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Loyalty.db3"));
                }
                return loyaltyDatabase;
            }
        }
        public App()
        {
            InitializeComponent();
            AppName = (string)Current.Resources["AppNameString"];
            
        }   
        protected override void OnStart()
        {
            if (IsNotified)
            {
                if (!string.IsNullOrEmpty(Global.GetNotifTopic()) && Global.GetNotifTopic() == "new_message")
                {
                    MainPage = new NavigationPage(new MessagesPage());
                    IsNotified = false;
                }
                else if (!string.IsNullOrEmpty(Global.GetNotifTopic()) && Global.GetNotifTopic() == "general")
                {
                    MainPage = new NavigationPage(new HomePage());
                    IsNotified = false;
                }
                else if (!string.IsNullOrEmpty(Global.GetNotifTopic()) && Global.GetNotifTopic() == "general_android")
                {
                    MainPage = new NavigationPage(new HomePage());
                    IsNotified = false;
                }
                else
                {
                    MainPage = new NavigationPage(new HomePage());
                    IsNotified = false;
                }
            }
            else
            {
                var page = new LoginPage();
                MainPage = new NavigationPage(page);
                //string action = "Logout";
                //MessagingCenter.Send<string>(action, "RemoveUserData");
            }
        }
        protected override void OnSleep()
        {

        }
       
    }
}