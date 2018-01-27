using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwapper : MonoBehaviour 
{
	public GameObject[] possibleTargets;

//	public GameObject replaceTargetPrefab;

	private int randy;
	// Use this for initialization
	void Start () 
	{
		possibleTargets = GameObject.FindGameObjectsWithTag ("FalseTarget");
		randy = Random.Range (0, possibleTargets.Length);
		possibleTargets [randy].tag = "Target";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
