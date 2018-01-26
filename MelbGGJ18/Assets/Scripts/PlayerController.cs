using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public float walkSpeed;
	public float turnSpeed;

	public Image distMarker;

	[SerializeField]
	private float targetDistance;

	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Target");
		distMarker = GameObject.FindGameObjectWithTag ("DistanceMarker").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		targetDistance = Vector3.Distance(transform.position, target.transform.position);		
		ProximitySensor ();
		Movement ();
	}

	public void Movement()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += transform.forward * walkSpeed;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.position += -transform.forward * walkSpeed;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate(0,-turnSpeed,0);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate(0,turnSpeed,0);
		}
	}
	public void ProximitySensor()
	{
//		distMarker.sprite targetDistance * 0.1f;
//		Debug.Log (targetDistance * 0.1f);
	}
}
