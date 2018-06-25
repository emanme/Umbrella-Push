package mono.com.mapbox.mapboxsdk.maps;


public class MapboxMap_OnMyLocationTrackingModeChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.maps.MapboxMap.OnMyLocationTrackingModeChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMyLocationTrackingModeChange:(I)V:GetOnMyLocationTrackingModeChange_IHandler:Com.Mapbox.Mapboxsdk.Maps.MapboxMap/IOnMyLocationTrackingModeChangeListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyLocationTrackingModeChangeListenerImplementor, Naxam.Mapbox.Droid", MapboxMap_OnMyLocationTrackingModeChangeListenerImplementor.class, __md_methods);
	}


	public MapboxMap_OnMyLocationTrackingModeChangeListenerImplementor ()
	{
		super ();
		if (getClass () == MapboxMap_OnMyLocationTrackingModeChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyLocationTrackingModeChangeListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onMyLocationTrackingModeChange (int p0)
	{
		n_onMyLocationTrackingModeChange (p0);
	}

	private native void n_onMyLocationTrackingModeChange (int p0);

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
