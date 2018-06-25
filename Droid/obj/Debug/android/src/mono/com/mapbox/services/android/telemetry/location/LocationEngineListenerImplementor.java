package mono.com.mapbox.services.android.telemetry.location;


public class LocationEngineListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.services.android.telemetry.location.LocationEngineListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConnected:()V:GetOnConnectedHandler:Com.Mapbox.Services.Android.Telemetry.Location.ILocationEngineListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"n_onLocationChanged:(Landroid/location/Location;)V:GetOnLocationChanged_Landroid_location_Location_Handler:Com.Mapbox.Services.Android.Telemetry.Location.ILocationEngineListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Services.Android.Telemetry.Location.ILocationEngineListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", LocationEngineListenerImplementor.class, __md_methods);
	}


	public LocationEngineListenerImplementor ()
	{
		super ();
		if (getClass () == LocationEngineListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Services.Android.Telemetry.Location.ILocationEngineListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", "", this, new java.lang.Object[] {  });
	}


	public void onConnected ()
	{
		n_onConnected ();
	}

	private native void n_onConnected ();


	public void onLocationChanged (android.location.Location p0)
	{
		n_onLocationChanged (p0);
	}

	private native void n_onLocationChanged (android.location.Location p0);

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
