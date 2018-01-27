using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisController : MonoBehaviour 
{
	//public GameObject currentCam;
	public GameObject irisCircle;
	private Transform targetPos;

	private RaycastHit hit;

	private Vector3 lastCastHit;

	public Vector3 irisScale;
	private float startIrisScale;
	public float irisMod;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		RayCaster ();
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) 
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
				irisMod = 0.99f;
				irisCircle.transform.localScale = irisCircle.transform.localScale * irisMod;
			}
		}
		else if (Vector3.Distance (hit.point, targetPos.position) > Vector3.Distance (lastCastHit, targetPos.position)) 
		{
			if (irisCircle.transform.localScale.x < 10f) 
			{
				irisMod = 1.01f;
				irisCircle.transform.localScale = irisCircle.transform.localScale * irisMod;
			}
		}
		lastCastHit = hit.point;
	}
	public void RayCaster()
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward*100);

		Physics.Raycast (this.transform.position, fwd, out hit,999f);
		Debug.DrawRay (this.transform.position, fwd, Color.black,1f,false);

		Debug.Log (Vector3.Distance (hit.point, targetPos.position));
		Debug.Log (hit.collider.gameObject);
	}
}
