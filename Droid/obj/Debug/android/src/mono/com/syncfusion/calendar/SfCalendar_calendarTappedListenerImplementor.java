package mono.com.syncfusion.calendar;


public class SfCalendar_calendarTappedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.syncfusion.calendar.SfCalendar.calendarTappedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCalendarTapped:(Ljava/lang/Object;Ljava/util/Calendar;Lcom/syncfusion/calendar/CalendarEventCollection;Lcom/syncfusion/calendar/CalendarInlineEvent;)V:GetOnCalendarTapped_Ljava_lang_Object_Ljava_util_Calendar_Lcom_syncfusion_calendar_CalendarEventCollection_Lcom_syncfusion_calendar_CalendarInlineEvent_Handler:Com.Syncfusion.Calendar.SfCalendar/ICalendarTappedListenerInvoker, Syncfusion.SfCalendar.Android\n" +
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Calendar.SfCalendar+ICalendarTappedListenerImplementor, Syncfusion.SfCalendar.Android", SfCalendar_calendarTappedListenerImplementor.class, __md_methods);
	}


	public SfCalendar_calendarTappedListenerImplementor ()
	{
		super ();
		if (getClass () == SfCalendar_calendarTappedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Calendar.SfCalendar+ICalendarTappedListenerImplementor, Syncfusion.SfCalendar.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCalendarTapped (java.lang.Object p0, java.util.Calendar p1, com.syncfusion.calendar.CalendarEventCollection p2, com.syncfusion.calendar.CalendarInlineEvent p3)
	{
		n_onCalendarTapped (p0, p1, p2, p3);
	}

	private native void n_onCalendarTapped (java.lang.Object p0, java.util.Calendar p1, com.syncfusion.calendar.CalendarEventCollection p2, com.syncfusion.calendar.CalendarInlineEvent p3);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
