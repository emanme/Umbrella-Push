using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;

namespace Umbrella.Utilities
{
    public static class Global
    {
        private static string user_id;
        private static string emailadd;
        private static string username;
        private static string password;
        private static int points { set; get; }
        private static byte barcodebyte { set; get; }
        private static string barcodestring = "barcode_image.png";

        private static Loyalty loyalty;

        private static string loyaltyBusiness;
        private static int loyaltyPartnerID;
        private static string loyaltyPackage;
        private static string loyaltyBarcodeNo;
        private static string loyaltyPoints = "0";
        private static int rewardPoints;
        private static string ranktitle;
        //notification
        private static int notifCount;
        private static int messageCount;
        private static string notifTopic;
        private static Dictionary<int, string> listTopic = new Dictionary<int, string>();
        private static List<Lead> listLeads = new List<Lead>();
        private static List<Medal> medalList = new List<Medal>();
        //private static List<TopComrades> topCom = new List<TopComrades>();
        private static List<TopRecruits> topRec = new List<TopRecruits>();
        //private static List<TopResources> topReso = new List<TopResources>();
        private static List<CalendarEvent> calendarWeek = new List<CalendarEvent>();
        private static List<CalendarEvent> calendarMonth = new List<CalendarEvent>();
        private static List<CalendarEvent> calendarYear = new List<CalendarEvent>();
        private static int num = 0;
        private static int recNum = 0;
        private static int topComNum = 0;
        private static int topResoNum = 0;
        private static int calendarMonthNum = 0;
        private static int calendarYearNum = 0;
        private static List<Message> topSecretUnreadTest = new List<Message>()
        {
                 new Message(){
                    Subject= "Test Top Secret",
                    Body = "This is a Top Secret Message!",
                    Image = "guy_gray",
                    HasAttachment = false,
                    Received = DateTime.Now

                }
        };
        #region GET 
        public static string GetUserId()
        {
            return user_id;
        }
        public static List<Message> GetTopUnreadTest()
        {
            return topSecretUnreadTest;
        }
        public static int GetNum()
        {
            return num;
        }
        public static int GetRecNum()
        {
            return recNum;
        }
        public static int GetCalendarMonthNum()
        {
            return calendarMonthNum;
        }
        public static int GetCalendarYearNum()
        {
            return calendarYearNum;
        }
        public static int GetTopComNum()
        {
            return topComNum;
        }
        public static int GetTopResoNum()
        {
            return topResoNum;
        }
        public static List<Medal> GetMedalList()
        {
            return medalList;
        }
        public static List<CalendarEvent> GetCalendarWeek()
        {
            return calendarWeek;
        }
        public static List<CalendarEvent> GetCalendarMonth()
        {
            return calendarMonth;
        }
        public static List<CalendarEvent> GetCalendarYear()
        {
            return calendarYear;
        }
        public static string Getpassword()
        {
            return password;
        }
        public static string GetUserEmail()
        {
            return emailadd;
        }
        public static string GetUsername()
        {
            return username;
        }
        public static string GetBarCodeString()
        {
            return barcodestring;
        }
        public static int GetNotifCount()
        {
            return notifCount;
        }
        public static int GetMessageCount()
        {
            return messageCount;
        }
        public static Dictionary<int, string> GetAllTopic()
        {
            return listTopic;
        }
        public static List<Lead> GetListLead()
        {
            return listLeads;
        }
      
        public static List<TopRecruits> GetTopRec()
        {
            return topRec;
        }
        public static string GetNotifTopic()
        {
            return notifTopic;
        }
        public static string GetLoyaltyPoints()
        {
            return loyaltyPoints;
        }
        public static int GetrewardPoints()
        {
            return rewardPoints;
        }
        public static string GetRankTitle()
        {
            return ranktitle;
        }
        public static Loyalty GetLoyalty()
        {
            return loyalty;
        }
        #endregion
        #region SET 
        public static void SetUserId(string id)
        {
            user_id = id;
        }
        public static void SetTopUnreadTest(List<Message> message)
        {
            topSecretUnreadTest = message;
        }
        public static void SetrewardPoints(int rank)
        {
            rewardPoints = rank;
        }
        public static void SetRankTitle(string rankTitle)
        {
            ranktitle = rankTitle;
        }
        public static void SetUserEmail(string email)
        {
            emailadd = email;
        }
        public static void SetLoyalty(Loyalty Loyalty)
        {
            loyalty = Loyalty;
        }
        public static void SetCalendarListWeek(List<CalendarEvent> list)
        {
            calendarWeek = list;
        }
        public static void SetCalendarListMonth(List<CalendarEvent> list)
        {
            calendarMonth = list;
        }
        public static void SetCalendarListYear(List<CalendarEvent> list)
        {
            calendarYear = list;
        }
        public static void SetMedalList(List<Medal> list)
        {
            medalList = list;
        }
        public static void SetTopRec(List<TopRecruits> list)
        {
            topRec = list;
        }
        public static void SetNum(int number)
        {
            num = num + number;
        }
        public static void SetRecAddNum(int number)
        {
            recNum = recNum + number;
        }
        public static void SetTopResoAddNum(int number)
        {
            topResoNum = topResoNum + number;
        }
        public static void SetTopComAddNum(int number)
        {
            topComNum = topComNum + number;
        }
        public static void SetRecNum(int number)
        {
            recNum = number;
        }
        public static void SetTopComNum(int number)
        {
            topComNum = number;
        }
        public static void SetTopResoNum(int number)
        {
            topResoNum = number;
        }
        public static void SetCalendarMonthAddNum(int number)
        {
            calendarMonthNum = calendarMonthNum + number;
        }
        public static void SetCalendarMonthNum(int number)
        {
            calendarMonthNum = number;
        }
        public static void SetCalendarYearAddNum(int number)
        {
            calendarYearNum = calendarYearNum + number;
        }
        public static void SetCalendarYearNum(int number)
        {
            calendarYearNum = number;
        }
        public static void SetNotifBadge(int num)
        {
            notifCount = num;
        }
        public static void SetMessageCount(int num)
        {
            messageCount = num;
        }
        public static void SetNotifTopic(string topic)
        {
            notifTopic = topic;
        }
        public static void SetListTopic(int id, string topic)
        {
            listTopic.Add(id, topic);
        }
        public static void SetAllTopic(Dictionary<int, string> list)
        {
            listTopic = list;
        }
        public static void SetListLead(List<Lead> leads)
        {
            listLeads = leads;
        }
        public static string SetBarCodeString(string barcodes) => barcodestring = barcodes;
        public static string SetLoyaltyPoints(string loyaltypoints) => loyaltyPoints = loyaltypoints;
        public static string Setusername(string _sername) => username = _sername;
        public static string Setpassword(string _password) => password = _password;
        // password
        #endregion
    }
}