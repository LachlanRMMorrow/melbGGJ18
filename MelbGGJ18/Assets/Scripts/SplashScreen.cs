using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	private float timer;
	public float timeToDisplaySplashScreen;
	public int nextLevelToLoad;

	// Use this for initialization
	void Start () 
	{
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time - timer > timeToDisplaySplashScreen) 
		{
			Application.LoadLevel(nextLevelToLoad);
		}
	}
}
