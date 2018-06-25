package md5abf35deb596c79c0ea79611a4f9422e9;


public class MyHandler
	extends android.content.AsyncQueryHandler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Plugin.Badge.MyHandler, Plugin.Badge", MyHandler.class, __md_methods);
	}


	public MyHandler (android.content.ContentResolver p0)
	{
		super (p0);
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("Plugin.Badge.MyHandler, Plugin.Badge", "Android.Content.ContentResolver, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
