package mono.com.mapbox.services.android.telemetry;


public class TelemetryListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.services.android.telemetry.TelemetryListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHttpFailure:(Ljava/lang/String;)V:GetOnHttpFailure_Ljava_lang_String_Handler:Com.Mapbox.Services.Android.Telemetry.ITelemetryListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"n_onHttpResponse:(ZI)V:GetOnHttpResponse_ZIHandler:Com.Mapbox.Services.Android.Telemetry.ITelemetryListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"n_onSendEvents:(I)V:GetOnSendEvents_IHandler:Com.Mapbox.Services.Android.Telemetry.ITelemetryListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Services.Android.Telemetry.ITelemetryListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", TelemetryListenerImplementor.class, __md_methods);
	}


	public TelemetryListenerImplementor ()
	{
		super ();
		if (getClass () == TelemetryListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Services.Android.Telemetry.ITelemetryListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", "", this, new java.lang.Object[] {  });
	}


	public void onHttpFailure (java.lang.String p0)
	{
		n_onHttpFailure (p0);
	}

	private native void n_onHttpFailure (java.lang.String p0);


	public void onHttpResponse (boolean p0, int p1)
	{
		n_onHttpResponse (p0, p1);
	}

	private native void n_onHttpResponse (boolean p0, int p1);


	public void onSendEvents (int p0)
	{
		n_onSendEvents (p0);
	}

	private native void n_onSendEvents (int p0);

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
