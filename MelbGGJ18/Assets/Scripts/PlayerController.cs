using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float walkSpeed;
	public float turnSpeed;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
}
