package md57472b21d1b48787378381251333b330d;


public class MultilineLabelRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.LabelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Umbrella.Droid.Renderers.MultilineLabelRenderer, Umbrella.Droid", MultilineLabelRenderer.class, __md_methods);
	}


	public MultilineLabelRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MultilineLabelRenderer.class)
			mono.android.TypeManager.Activate ("Umbrella.Droid.Renderers.MultilineLabelRenderer, Umbrella.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MultilineLabelRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MultilineLabelRenderer.class)
			mono.android.TypeManager.Activate ("Umbrella.Droid.Renderers.MultilineLabelRenderer, Umbrella.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MultilineLabelRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MultilineLabelRenderer.class)
			mono.android.TypeManager.Activate ("Umbrella.Droid.Renderers.MultilineLabelRenderer, Umbrella.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
