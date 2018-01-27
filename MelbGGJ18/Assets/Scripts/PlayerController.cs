using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public float walkSpeed;
	public float turnSpeed;

	public bool isWalking;

	private Animator myAnimator;

	public Color newColor;

	public GameObject winScreen;

	public Image distMarker;

	[SerializeField]
	private float targetDistance;

	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		myAnimator = this.gameObject.GetComponent<Animator> ();
		isWalking = false;
		winScreen.SetActive (false);
		target = GameObject.FindGameObjectWithTag ("Target");
		distMarker = GameObject.FindGameObjectWithTag ("DistanceMarker").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (target == null) 
		{
			target = GameObject.FindGameObjectWithTag ("Target");
		}
		if (isWalking == true) 
		{
			myAnimator.SetBool ("IsWalking", true);
		} 
		else 
		{
			myAnimator.SetBool ("IsWalking", false);
		}
		ProximitySensor ();
		Movement ();
		PickupDiamond ();
	}

	public void Movement()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			isWalking = true;
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward*walkSpeed);
//			transform.position += transform.forward * walkSpeed;
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			isWalking = true;
			gameObject.GetComponent<Rigidbody> ().AddForce (-transform.forward*walkSpeed);
//			transform.position += -transform.forward * walkSpeed;
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate(0,-turnSpeed,0);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate(0,turnSpeed,0);
		}
		if (Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false && Input.GetKey (KeyCode.A) == false && Input.GetKey (KeyCode.D) == false)
		{
			isWalking = false;
			gameObject.GetComponent<Rigidbody> ().velocity += -gameObject.GetComponent<Rigidbody> ().velocity;
			gameObject.GetComponent<Rigidbody> ().angularVelocity += -gameObject.GetComponent<Rigidbody> ().angularVelocity;
		}
	}
	public void ProximitySensor()
	{
		if ((transform.position - target.transform.position).magnitude < 100f) 
		{
			targetDistance = (transform.position - target.transform.position).magnitude;
			distMarker.color = new Color(distMarker.color.r,distMarker.color.g,distMarker.color.b, 1 - (targetDistance*0.1f));
			//Debug.Log (distMarker.color.ToString());
		}

	}
	public void PickupDiamond()
	{
		if (Vector3.Distance (transform.position, target.transform.position) < 3f && Input.GetKey(KeyCode.Space)) 
		{
			target.SetActive (false);
			winScreen.SetActive (true);
		}
	}
}
