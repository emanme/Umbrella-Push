package mono.com.almeros.android.multitouch.gesturedetectors;


public class MoveGestureDetector_OnMoveGestureListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector.OnMoveGestureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMove:(Lcom/almeros/android/multitouch/gesturedetectors/MoveGestureDetector;)Z:GetOnMove_Lcom_almeros_android_multitouch_gesturedetectors_MoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.MoveGestureDetector/IOnMoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onMoveBegin:(Lcom/almeros/android/multitouch/gesturedetectors/MoveGestureDetector;)Z:GetOnMoveBegin_Lcom_almeros_android_multitouch_gesturedetectors_MoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.MoveGestureDetector/IOnMoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onMoveEnd:(Lcom/almeros/android/multitouch/gesturedetectors/MoveGestureDetector;)V:GetOnMoveEnd_Lcom_almeros_android_multitouch_gesturedetectors_MoveGestureDetector_Handler:Com.Almeros.Android.Multitouch.Gesturedetectors.MoveGestureDetector/IOnMoveGestureListenerInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Almeros.Android.Multitouch.Gesturedetectors.MoveGestureDetector+IOnMoveGestureListenerImplementor, Naxam.Mapbox.Droid", MoveGestureDetector_OnMoveGestureListenerImplementor.class, __md_methods);
	}


	public MoveGestureDetector_OnMoveGestureListenerImplementor ()
	{
		super ();
		if (getClass () == MoveGestureDetector_OnMoveGestureListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Almeros.Android.Multitouch.Gesturedetectors.MoveGestureDetector+IOnMoveGestureListenerImplementor, Naxam.Mapbox.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onMove (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0)
	{
		return n_onMove (p0);
	}

	private native boolean n_onMove (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0);


	public boolean onMoveBegin (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0)
	{
		return n_onMoveBegin (p0);
	}

	private native boolean n_onMoveBegin (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0);


	public void onMoveEnd (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0)
	{
		n_onMoveEnd (p0);
	}

	private native void n_onMoveEnd (com.almeros.android.multitouch.gesturedetectors.MoveGestureDetector p0);

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
