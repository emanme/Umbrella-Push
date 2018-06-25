package mono.com.mapbox.mapboxsdk.maps;


public class MapboxMap_OnMyBearingTrackingModeChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.maps.MapboxMap.OnMyBearingTrackingModeChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMyBearingTrackingModeChange:(I)V:GetOnMyBearingTrackingModeChange_IHandler:Com.Mapbox.Mapboxsdk.Maps.MapboxMap/IOnMyBearingTrackingModeChangeListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyBearingTrackingModeChangeListenerImplementor, Naxam.Mapbox.Droid", MapboxMap_OnMyBearingTrackingModeChangeListenerImplementor.class, __md_methods);
	}


	public MapboxMap_OnMyBearingTrackingModeChangeListenerImplementor ()
	{
		super ();
		if (getClass () == MapboxMap_OnMyBearingTrackingModeChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Maps.MapboxMap+IOnMyBearingTrackingModeChangeListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onMyBearingTrackingModeChange (int p0)
	{
		n_onMyBearingTrackingModeChange (p0);
	}

	private native void n_onMyBearingTrackingModeChange (int p0);

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
