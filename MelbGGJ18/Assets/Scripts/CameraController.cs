using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public GameObject currentCam;
	public GameObject irisCircle;
	private Transform targetPos;

	private RaycastHit hit;

	private Vector3 lastCastHit;

	public Vector3 irisScale;
	private float startIrisScale;
	public float irisMod;

	float speed = 10.0f;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start () 
	{
		targetPos = GameObject.FindGameObjectWithTag ("Target").GetComponent<Transform> ();
		Cursor.lockState = CursorLockMode.Locked;
		irisMod = 1;
		Cursor.visible = false;
		RaycastHit lastHit;
		Physics.Raycast (this.transform.position, transform.TransformDirection(Vector3.forward), out lastHit,8);
		lastCastHit = lastHit.point;
//		Debug.Log (lastCastHit);
	}
	
	// Update is called once per frame
	void Update () 
	{
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		RayCaster ();
		if (Input.GetAxis ("Mouse X") > 0f || Input.GetAxis ("Mouse Y") > 0f) 
		{
			IrisScaler ();
		}
	}
	public void IrisScaler ()
	{
		
		if (Vector3.Distance (hit.point, targetPos.position) < Vector3.Distance (lastCastHit, targetPos.position))
		{
			if(irisCircle.transform.localScale.x > 0.2f)
			{
				irisMod = 0.9f;
				irisCircle.transform.localScale = irisCircle.transform.localScale * irisMod;
			}
		}
		else if (Vector3.Distance (hit.point, targetPos.position) > Vector3.Distance (lastCastHit, targetPos.position)) 
		{
			if (irisCircle.transform.localScale.x < 10f) 
			{
				irisMod = 1.1f;
				irisCircle.transform.localScale = irisCircle.transform.localScale * irisMod;
			}
		}
//		Debug.Log (Vector3.Distance (hit.point, targetPos.position));
		lastCastHit = hit.point;
	}
	public void RayCaster()
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		Physics.Raycast (this.transform.position, fwd, out hit, 999f);
	}
}
