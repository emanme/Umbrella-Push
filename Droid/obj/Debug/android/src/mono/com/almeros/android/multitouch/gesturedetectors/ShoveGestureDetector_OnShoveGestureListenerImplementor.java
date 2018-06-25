package mono.com.almeros.android.multitouch.gesturedetectors;


public class ShoveGestureDetector_OnShoveGestureListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector.OnShoveGestureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onShove:(Lcom/almeros/android/multitouch/gesturedetectors/ShoveGestureDetector;)Z:GetOnShove_Lcom_almeros_android_multitouch_gesturedetectors_ShoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.ShoveGestureDetector/IOnShoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onShoveBegin:(Lcom/almeros/android/multitouch/gesturedetectors/ShoveGestureDetector;)Z:GetOnShoveBegin_Lcom_almeros_android_multitouch_gesturedetectors_ShoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.ShoveGestureDetector/IOnShoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onShoveEnd:(Lcom/almeros/android/multitouch/gesturedetectors/ShoveGestureDetector;)V:GetOnShoveEnd_Lcom_almeros_android_multitouch_gesturedetectors_ShoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.ShoveGestureDetector/IOnShoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Almeros.Android.Multitouch.Gesturedetectors.ShoveGestureDetector+IOnShoveGestureListenerImplementor, Naxam.Mapbox.Droid", ShoveGestureDetector_OnShoveGestureListenerImplementor.class, __md_methods);
	}


	public ShoveGestureDetector_OnShoveGestureListenerImplementor ()
	{
		super ();
		if (getClass () == ShoveGestureDetector_OnShoveGestureListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Almeros.Android.Multitouch.Gesturedetectors.ShoveGestureDetector+IOnShoveGestureListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onShove (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0)
	{
		return n_onShove (p0);
	}

	private native boolean n_onShove (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0);


	public boolean onShoveBegin (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0)
	{
		return n_onShoveBegin (p0);
	}

	private native boolean n_onShoveBegin (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0);


	public void onShoveEnd (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0)
	{
		n_onShoveEnd (p0);
	}

	private native void n_onShoveEnd (com.almeros.android.multitouch.gesturedetectors.ShoveGestureDetector p0);

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
