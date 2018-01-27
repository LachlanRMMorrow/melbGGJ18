using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardManager : MonoBehaviour 
{
	public GameObject visionCone;

	[SerializeField]
	private GameObject[] guardPatrolPoints;

	[SerializeField]
	private int currentPatrolPoint;

	// Use this for initialization
	void Start () 
	{
		currentPatrolPoint = 0;
		this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (guardPatrolPoints [currentPatrolPoint].transform.position);
		guardPatrolPoints = GameObject.FindGameObjectsWithTag ("GuardPatrolPoint");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.GetComponent<NavMeshAgent> ().destination == null) 
		{
			currentPatrolPoint = currentPatrolPoint + 1;
			this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (guardPatrolPoints [currentPatrolPoint].transform.position);
		}
		if (currentPatrolPoint == guardPatrolPoints.Length + 1) 
		{
			currentPatrolPoint = 0;
		}
	}
}
