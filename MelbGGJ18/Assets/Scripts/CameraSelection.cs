using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour {

    public GameObject CameraController;

    public Animator anim;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
         if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("North");
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("East");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("South");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("West");
        }

    }

}
