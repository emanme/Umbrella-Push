package mono.com.mapbox.mapboxsdk.maps;


public class MapboxMap_OnMyLocationChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.maps.MapboxMap.OnMyLocationChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMyLocationChange:(Landroid/location/Location;)V:GetOnMyLocationChange_Landroid_location_Location_Handler:Com.Mapbox.Mapboxsdk.Maps.MapboxMap/IOnMyLocationChangeListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyLocationChangeListenerImplementor, Naxam.Mapbox.Droid", MapboxMap_OnMyLocationChangeListenerImplementor.class, __md_methods);
	}


	public MapboxMap_OnMyLocationChangeListenerImplementor ()
	{
		super ();
		if (getClass () == MapboxMap_OnMyLocationChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyLocationChangeListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onMyLocationChange (android.location.Location p0)
	{
		n_onMyLocationChange (p0);
	}

	private native void n_onMyLocationChange (android.location.Location p0);

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
