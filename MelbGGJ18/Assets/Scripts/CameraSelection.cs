using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class CameraSelection : MonoBehaviour {

    public GameObject CameraController;

    public float grainLevel;
    
    public float transitionTime;
    public Image transitionImage;

    public PostProcessingProfile postProProfile;

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
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("North");
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("East");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("South");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("West");
        }
    }

    void Transition()
    {
        //Grain Activate
        GrainModel.Settings grainSettings = postProProfile.grain.settings;
        grainSettings.intensity = 1;
        postProProfile.grain.settings = grainSettings;
        //Grey Activate
        transitionImage.gameObject.SetActive(true);    
    }


    IEnumerator ResetGrain(float waitTime)
    {
        //Wait
        yield return new WaitForSeconds(waitTime);
        //Grey Reset
        transitionImage.gameObject.SetActive(false);
        //Grain Reset
        GrainModel.Settings grainSettings = postProProfile.grain.settings;
        grainSettings.intensity = grainLevel;
        postProProfile.grain.settings = grainSettings;
    }

}
