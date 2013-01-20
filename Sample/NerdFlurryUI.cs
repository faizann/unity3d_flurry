using UnityEngine;
using System.Collections;

public class NerdFlurryUI : MonoBehaviour {
	
	private string FLURRY_API_KEY = "BQTJ2PM33Q5KNKFV23VG";	
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
		
		if(GUILayout.Button("Timed Event Start", GUILayout.Height(60)))
		{
			mNerdFlurry.LogEvent("Timer 2",true);
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
