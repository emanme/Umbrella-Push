package md5b7c492bd37a1a5d0e7ea7a91d28d95cb;


public class MyFirebaseMessagingService
	extends com.google.firebase.messaging.FirebaseMessagingService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleIntent:(Landroid/content/Intent;)V:GetHandleIntent_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Umbrella.Droid.Services.MyFirebaseMessagingService, Umbrella.Droid", MyFirebaseMessagingService.class, __md_methods);
	}


	public MyFirebaseMessagingService ()
	{
		super ();
		if (getClass () == MyFirebaseMessagingService.class)
			mono.android.TypeManager.Activate ("Umbrella.Droid.Services.MyFirebaseMessagingService, Umbrella.Droid", "", this, new java.lang.Object[] {  });
	}


	public void handleIntent (android.content.Intent p0)
	{
		n_handleIntent (p0);
	}

	private native void n_handleIntent (android.content.Intent p0);

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
