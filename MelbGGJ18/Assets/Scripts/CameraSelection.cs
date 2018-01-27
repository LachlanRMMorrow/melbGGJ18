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
    public Image Reticle;
    public AudioClip transitionSound;
    public AudioSource audioSource;

    public PostProcessingProfile postProProfile;

    public Animator anim;
	
    void Start()
    {
        //Recticle Activate
        Reticle.gameObject.SetActive(true);
        //Grey Reset
        transitionImage.gameObject.SetActive(false);
        //Grain Reset
        GrainModel.Settings grainSettings = postProProfile.grain.settings;
        grainSettings.intensity = grainLevel;
        postProProfile.grain.settings = grainSettings;
    }

	// Update is called once per frame
	void Update ()
    {
         if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("Camera1");
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("Camera2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("Camera3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Transition();
            StartCoroutine(ResetGrain(transitionTime));
            anim.SetTrigger("Camera4");
        }
    }

    void Transition()
    {

        float rndm = Random.Range(0.75f, 1.0f);

        //Grain Activate
        GrainModel.Settings grainSettings = postProProfile.grain.settings;
        grainSettings.intensity = 1;
        postProProfile.grain.settings = grainSettings;
        //Grey Activate
        transitionImage.gameObject.SetActive(true);
        //Reticle Reset
        Reticle.gameObject.SetActive(false);
        //Transition Sound
        audioSource.pitch = rndm;
        audioSource.PlayOneShot(transitionSound, 0.75f);
    }


    IEnumerator ResetGrain(float waitTime)
    {
        //Wait
        yield return new WaitForSeconds(waitTime);
        //Recticle Activate
        Reticle.gameObject.SetActive(true);
        //Grey Reset
        transitionImage.gameObject.SetActive(false);
        //Grain Reset
        GrainModel.Settings grainSettings = postProProfile.grain.settings;
        grainSettings.intensity = grainLevel;
        postProProfile.grain.settings = grainSettings;
        //Transition Sound Stop
        audioSource.Stop();
    }

}
