using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManager : MonoBehaviour 
{
	public GameObject visionCone;
	public GameObject[] guardPatrolPoints;

	// Use this for initialization
	void Start () 
	{
		guardPatrolPoints = GameObject.FindGameObjectsWithTag ("GuardPatrolPoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
