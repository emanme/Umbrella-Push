package mono.com.mapzen.android.lost.api;


public class LocationListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapzen.android.lost.api.LocationListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationChanged:(Landroid/location/Location;)V:GetOnLocationChanged_Landroid_location_Location_Handler:Mapzen.Lost.Api.ILocationListenerInvoker, Naxam.Mapzen.Lost.Droid\n" +
			"";
		mono.android.Runtime.register ("Mapzen.Lost.Api.ILocationListenerImplementor, Naxam.Mapzen.Lost.Droid", LocationListenerImplementor.class, __md_methods);
	}


	public LocationListenerImplementor ()
	{
		super ();
		if (getClass () == LocationListenerImplementor.class)
			mono.android.TypeManager.Activate ("Mapzen.Lost.Api.ILocationListenerImplementor, Naxam.Mapzen.Lost.Droid", "", this, new java.lang.Object[] {  });
	}


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
