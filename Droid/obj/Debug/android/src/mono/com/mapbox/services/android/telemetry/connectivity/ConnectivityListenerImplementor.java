package mono.com.mapbox.services.android.telemetry.connectivity;


public class ConnectivityListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.services.android.telemetry.connectivity.ConnectivityListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConnectivityChanged:(Z)V:GetOnConnectivityChanged_ZHandler:Com.Mapbox.Services.Android.Telemetry.Connectivity.IConnectivityListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Services.Android.Telemetry.Connectivity.IConnectivityListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", ConnectivityListenerImplementor.class, __md_methods);
	}


	public ConnectivityListenerImplementor ()
	{
		super ();
		if (getClass () == ConnectivityListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Services.Android.Telemetry.Connectivity.IConnectivityListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", "", this, new java.lang.Object[] {  });
	}


	public void onConnectivityChanged (boolean p0)
	{
		n_onConnectivityChanged (p0);
	}

	private native void n_onConnectivityChanged (boolean p0);

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
