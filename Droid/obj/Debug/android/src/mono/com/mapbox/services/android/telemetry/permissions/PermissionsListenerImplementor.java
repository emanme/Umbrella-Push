package mono.com.mapbox.services.android.telemetry.permissions;


public class PermissionsListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.services.android.telemetry.permissions.PermissionsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onExplanationNeeded:(Ljava/util/List;)V:GetOnExplanationNeeded_Ljava_util_List_Handler:Com.Mapbox.Services.Android.Telemetry.Permissions.IPermissionsListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"n_onPermissionResult:(Z)V:GetOnPermissionResult_ZHandler:Com.Mapbox.Services.Android.Telemetry.Permissions.IPermissionsListenerInvoker, Naxam.Mapbox.Services.Android.Telemetry\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Services.Android.Telemetry.Permissions.IPermissionsListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", PermissionsListenerImplementor.class, __md_methods);
	}


	public PermissionsListenerImplementor ()
	{
		super ();
		if (getClass () == PermissionsListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Services.Android.Telemetry.Permissions.IPermissionsListenerImplementor, Naxam.Mapbox.Services.Android.Telemetry", "", this, new java.lang.Object[] {  });
	}


	public void onExplanationNeeded (java.util.List p0)
	{
		n_onExplanationNeeded (p0);
	}

	private native void n_onExplanationNeeded (java.util.List p0);


	public void onPermissionResult (boolean p0)
	{
		n_onPermissionResult (p0);
	}

	private native void n_onPermissionResult (boolean p0);

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
