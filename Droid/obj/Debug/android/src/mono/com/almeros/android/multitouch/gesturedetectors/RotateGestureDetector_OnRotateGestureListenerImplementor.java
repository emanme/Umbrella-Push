package mono.com.almeros.android.multitouch.gesturedetectors;


public class RotateGestureDetector_OnRotateGestureListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector.OnRotateGestureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRotate:(Lcom/almeros/android/multitouch/gesturedetectors/RotateGestureDetector;)Z:GetOnRotate_Lcom_almeros_android_multitouch_gesturedetectors_RotateGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.RotateGestureDetector/IOnRotateGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onRotateBegin:(Lcom/almeros/android/multitouch/gesturedetectors/RotateGestureDetector;)Z:GetOnRotateBegin_Lcom_almeros_android_multitouch_gesturedetectors_RotateGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.RotateGestureDetector/IOnRotateGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onRotateEnd:(Lcom/almeros/android/multitouch/gesturedetectors/RotateGestureDetector;)V:GetOnRotateEnd_Lcom_almeros_android_multitouch_gesturedetectors_RotateGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.RotateGestureDetector/IOnRotateGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Almeros.Android.Multitouch.Gesturedetectors.RotateGestureDetector+IOnRotateGestureListenerImplementor, Naxam.Mapbox.Droid", RotateGestureDetector_OnRotateGestureListenerImplementor.class, __md_methods);
	}


	public RotateGestureDetector_OnRotateGestureListenerImplementor ()
	{
		super ();
		if (getClass () == RotateGestureDetector_OnRotateGestureListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Almeros.Android.Multitouch.Gesturedetectors.RotateGestureDetector+IOnRotateGestureListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onRotate (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0)
	{
		return n_onRotate (p0);
	}

	private native boolean n_onRotate (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0);


	public boolean onRotateBegin (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0)
	{
		return n_onRotateBegin (p0);
	}

	private native boolean n_onRotateBegin (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0);


	public void onRotateEnd (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0)
	{
		n_onRotateEnd (p0);
	}

	private native void n_onRotateEnd (com.almeros.android.multitouch.gesturedetectors.RotateGestureDetector p0);

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
