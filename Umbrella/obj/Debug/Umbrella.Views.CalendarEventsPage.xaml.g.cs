//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Umbrella.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("/Users/bbeight/Documents/marksobiaco-ios-army-app-e48f18fb97e7 2/src/Umbrella/Vie" +
        "ws/CalendarEventsPage.xaml")]
    public partial class CalendarEventsPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.StackLayout AppointmentsTabs;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.TabButton WeekTab;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.TabButton MonthTab;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.TabButton YearTab;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.SystemListView EventsListViewWeek;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.SystemListView EventsListViewMonth;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Umbrella.Controls.SystemListView EventsListViewYear;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.AbsoluteLayout BusyIndicator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Syncfusion.SfBusyIndicator.XForms.SfBusyIndicator Indicator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(CalendarEventsPage));
            AppointmentsTabs = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "AppointmentsTabs");
            WeekTab = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.TabButton>(this, "WeekTab");
            MonthTab = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.TabButton>(this, "MonthTab");
            YearTab = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.TabButton>(this, "YearTab");
            EventsListViewWeek = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.SystemListView>(this, "EventsListViewWeek");
            EventsListViewMonth = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.SystemListView>(this, "EventsListViewMonth");
            EventsListViewYear = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Umbrella.Controls.SystemListView>(this, "EventsListViewYear");
            BusyIndicator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.AbsoluteLayout>(this, "BusyIndicator");
            Indicator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.SfBusyIndicator.XForms.SfBusyIndicator>(this, "Indicator");
        }
    }
}
