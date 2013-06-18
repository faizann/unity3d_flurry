using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NerdFlurryUI : MonoBehaviour {
	
	private string FLURRY_API_KEY = "YOUR_API_KEY";	
	private NerdFlurry mNerdFlurry = null;
	// Use this for initialization
	void Start () {
		mNerdFlurry = new NerdFlurry();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}
	
	
	void OnGUI()
	{ 
		GUILayout.BeginVertical();
		
		if(GUILayout.Button("Start Flurry",GUILayout.Height(60)))
		{
			mNerdFlurry.StartSession(FLURRY_API_KEY);
		}
		if(GUILayout.Button("Agent Version",GUILayout.Height(60)))
		{
			Debug.Log("Agent version is "+mNerdFlurry.GetAgentVersion());
		}
		if(GUILayout.Button("Log Event 1", GUILayout.Height(60)))
		{
			mNerdFlurry.LogEvent("Event 2");
		}
		if(GUILayout.Button("Log Event 1 with params", GUILayout.Height(60)))
		{
			Dictionary<string, string> kvps = new Dictionary<string, string>();
			kvps.Add("GameName","MyGame");
			kvps.Add("Level","Level1");
			mNerdFlurry.LogEvent("Event 3",kvps);
		}
		
		if(GUILayout.Button("Timed Log Event 1 with params", GUILayout.Height(60)))
		{
			Dictionary<string, string> kvps = 	 new Dictionary<string, string>();
			kvps.Add("GameName","MyGame");
			kvps.Add("Level","Level1");
			mNerdFlurry.LogEvent("Timer 2",kvps,true);
		}
		
		if(GUILayout.Button("Timed Event Start", GUILayout.Height(60)))
		{
			Dictionary<string, string> kvps = 	 new Dictionary<string, string>();
			kvps.Add("TGameName","MyGame");
			kvps.Add("TLevel","Level1");
			mNerdFlurry.LogEvent("Timer 2",kvps,true);
		}
		
		if(GUILayout.Button("Timed Event End", GUILayout.Height(60)))
		{
			mNerdFlurry.EndTimedEvent("Timer 2");
		}
		
		if(GUILayout.Button("End Session", GUILayout.Height(60)))
		{
			mNerdFlurry.EndSession();
		}
		
		GUILayout.EndVertical();	
	}
	
	void OnApplicationQuit()
	{
		mNerdFlurry.EndSession();
	}
}
