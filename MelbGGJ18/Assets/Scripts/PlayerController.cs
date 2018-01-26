using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public float walkSpeed;
	public float turnSpeed;

	public Color newColor;

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
		if ((transform.position - target.transform.position).magnitude < 100f) 
		{
			targetDistance = (transform.position - target.transform.position).magnitude;
			distMarker.color = new Color(distMarker.color.r,distMarker.color.g,distMarker.color.b, 1 - (targetDistance*0.1f));
			Debug.Log (distMarker.color.ToString());
		}

	}
}
