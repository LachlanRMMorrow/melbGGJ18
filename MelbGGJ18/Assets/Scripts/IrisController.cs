using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IrisController : MonoBehaviour 
{
	//public GameObject currentCam;
	public Image irisCircle;
	public Transform targetPos;

	private RaycastHit hit;

	private Vector3 lastCastHit;

	public float irisScale;
    public float irisMax;

	// Use this for initialization
	void Start () 
	{
		targetPos = GameObject.FindGameObjectWithTag ("Target").GetComponent<Transform> ();
		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		RaycastHit lastHit;
		Physics.Raycast (this.transform.position, transform.TransformDirection(Vector3.forward), out lastHit);
		lastCastHit = lastHit.point;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (targetPos == null) 
		{
			targetPos = GameObject.FindGameObjectWithTag ("Target").GetComponent<Transform> ();
		}
		RayCaster ();
		IrisScaler ();
	}
	public void IrisScaler ()
	{    
        float temp = Vector3.Distance(hit.point, targetPos.position);

        irisCircle.rectTransform.localScale = new Vector3(Mathf.Clamp(irisScale * temp * 1.0f,irisScale,irisMax), 
            Mathf.Clamp((irisScale * temp * 1.0f), irisScale, irisMax), 
            1);
    }

	public void RayCaster()
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward*100);

		Physics.Raycast (this.transform.position, fwd, out hit,999f);
		Debug.DrawRay (this.transform.position, fwd, Color.black,1f,false);

		//Debug.Log (Vector3.Distance (hit.point, targetPos.position));
		//Debug.Log (hit.collider.gameObject);
	}
}
