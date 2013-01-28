using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;

	
public class NerdFlurry : MonoBehaviour {
	
#if UNITY_ANDROID
	private AndroidJavaObject mCurrentActivity = null;
	private AndroidJavaClass mFlurryClass = null;
	// Use this for initialization
	public NerdFlurry() {
		if(Application.platform==RuntimePlatform.Android)
		{	
			AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			mCurrentActivity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
			mFlurryClass = new AndroidJavaClass("com.flurry.android.FlurryAgent");
		}
	}
	
	public void StartSession(string API_KEY)
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			mFlurryClass.CallStatic("setLogLevel",2);
			mFlurryClass.CallStatic("setLogEnabled",true);
			mFlurryClass.CallStatic("setLogEvents", true);
				
			mFlurryClass.CallStatic("setCaptureUncaughtExceptions", true);
				
			mFlurryClass.CallStatic("onStartSession", mCurrentActivity,API_KEY);
		}
	}
	
	public void EndSession()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			mFlurryClass.CallStatic("onEndSession",mCurrentActivity);
		}
	}
	
	public int GetAgentVersion()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			return mFlurryClass.CallStatic<int>("getAgentVersion");
		}
		
		return 0;
	}
	
	public void LogEvent(string eventId, bool timed=false)
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			if(timed==false)
				mFlurryClass.CallStatic("logEvent",eventId);
			else
				mFlurryClass.CallStatic("logEvent",eventId,true);
		}
	}
	
	public void LogEvent (string eventId, Dictionary<string, string> parameters, bool timed=false)
	{
		using(AndroidJavaObject obj_HashMap = new AndroidJavaObject("java.util.HashMap")) 
    	{

	        // Call 'put' via the JNI instead of using helper classes to avoid:
	        //  "JNI: Init'd AndroidJavaObject with null ptr!"
	        System.IntPtr method_Put = AndroidJNIHelper.GetMethodID(obj_HashMap.GetRawClass(), "put", 
	
	            "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
	
	        object[] args = new object[2];
	
	        foreach(KeyValuePair<string, string> kvp in parameters)
	        {
	            using(AndroidJavaObject k = new AndroidJavaObject("java.lang.String", kvp.Key))
	            {
	                using(AndroidJavaObject v = new AndroidJavaObject("java.lang.String", kvp.Value))
	                {
	                    args[0] = k;
	                    args[1] = v;
	                    AndroidJNI.CallObjectMethod(obj_HashMap.GetRawObject(), 
	                        method_Put, AndroidJNIHelper.CreateJNIArgArray(args));
	                }
	            }
	        }
			if(timed==false)
	        	mFlurryClass.CallStatic("logEvent", eventId, obj_HashMap);
			else
				mFlurryClass.CallStatic("logEvent", eventId, obj_HashMap,true);
		}
	}
	
	public void EndTimedEvent(string eventId)
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			mFlurryClass.CallStatic("endTimedEvent",eventId);
		}
	}
	
#elif UNITY_IPHONE
	
#region NerdFlurry_Imports
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_startSession([In, MarshalAs(UnmanagedType.LPStr)]string apiKey);
	
/*	[DllImport("__Internal")]
	[return: MarshalAs(UnmanagedType.LPStr)]
    private static extern string NerdFlurry_getFlurryAgentVersion();
	*/
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setShowErrorInLogEnabled(bool bEnabled);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setDebugLogEnabled(bool bEnabled);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setEventLoggingEnabled(bool bEnabled);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setSessionReportsOnCloseEnabled(bool bEnabled);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setSessionReportsOnPauseEnabled(bool bEnabled);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setAge(int age);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_setAppVersion([In, MarshalAs(UnmanagedType.LPStr)]string version);
	
	[DllImport("__Internal")]
    private static extern void NerdFlurry_setSessionContinueSeconds(int seconds);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_setUserID([In, MarshalAs(UnmanagedType.LPStr)]string userId);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_logEvent([In, MarshalAs(UnmanagedType.LPStr)]string evendId);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_logEventWithParameters(
				[In, MarshalAs(UnmanagedType.LPStr)]string evendId, 
				[In, MarshalAs(UnmanagedType.LPStr)]string parameters);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_logEventWithParametersTimed(
				[In, MarshalAs(UnmanagedType.LPStr)]string evendId, 
				[In, MarshalAs(UnmanagedType.LPStr)]string parameters);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_logEventTimed([In, MarshalAs(UnmanagedType.LPStr)]string evendId);
	
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
    private static extern void NerdFlurry_endTimedEvent([In, MarshalAs(UnmanagedType.LPStr)]string evendId);
	
#endregion
	
	public void StartSession(string API_KEY)
	{
		NerdFlurry_setDebugLogEnabled(true);
		NerdFlurry_setShowErrorInLogEnabled(true);
		NerdFlurry_setEventLoggingEnabled(true);
		NerdFlurry_startSession(API_KEY);
	}
	
	public void EndSession()
	{
		return ; // there is no such thing as endSession in iOS API
	}
	
	public int GetAgentVersion()
	{	
		/*string version = NerdFlurry_getFlurryAgentVersion();
		Debug.Log("version is "+version);
		if(version!=null)
			return System.Convert.ToInt32(version);*/
		return 0;
	}
	
	public void LogEvent(string eventId, bool timed=false)
	{
		if(timed==false)
			NerdFlurry_logEvent(eventId);
		else
			NerdFlurry_logEventTimed(eventId);
	}
	
	public void LogEvent(string eventId, Dictionary<string, string> parameters, bool timed=false)
	{
		string strParams = "";
		foreach(KeyValuePair<string, string> kvp in parameters)
	    {
			strParams += kvp.Key +"="+kvp.Value+"\n";
		}
		if(timed==false)
			NerdFlurry_logEventWithParameters(eventId,strParams);
		else
			NerdFlurry_logEventWithParametersTimed(eventId,strParams);
	}
	
	public void EndTimedEvent(string eventId)
	{
		NerdFlurry_endTimedEvent(eventId);
	}
	
	public void SetAge(int age)
	{
		NerdFlurry_setAge(age);
	}
	
#else
	public void StartSession(string API_KEY)
	{
	
	}
	
	public void EndSession()
	{
	
	}
	
	public int GetAgentVersion()
	{
		
		return 0;
	}
	
	public void LogEvent(string eventId, bool timed=false)
	{
	
	}
	public void LogEvent(string eventId, Dictionary<string, string> parameters, bool timed=false)
	{
		
	}
	public void EndTimedEvent(string eventId)
	{
	
	}
#endif
}
