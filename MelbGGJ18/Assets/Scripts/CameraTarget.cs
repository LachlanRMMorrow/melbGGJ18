using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    public GameObject[] targets;

    public float speed = 10;

    [SerializeField]
    private GameObject curTarget;
    


    void Start()
    {
        curTarget = targets[0];
    }

    // Update is called once per frame
    void Update()
    {

        CheckTarget();

        MoveTarget();
        
    }

    void CheckTarget()
    {
        //Camera1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
            curTarget = targets[0];
        }
        //Camera2
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
            curTarget = targets[1];
        }
        //Camera3
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
            curTarget = targets[2];
        }
        //Camera4
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
            curTarget = targets[3];
        }
    }

    void MoveTarget()
    {
        //Camera1
        if(curTarget == targets[0])
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVerticle = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(-moveHorizontal, moveVerticle, 0.0f);
            
            curTarget.GetComponent<Rigidbody>().velocity = (movement * speed);
            
        }
        //Camera2
        else if(curTarget == targets[1])
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVerticle = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, moveVerticle, -moveHorizontal);

            curTarget.GetComponent<Rigidbody>().velocity = (movement * speed);
                       
        }
        //Camera3
        else if(curTarget == targets[2])
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVerticle = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, moveVerticle, moveHorizontal);

            curTarget.GetComponent<Rigidbody>().velocity = (movement * speed);

        }
        //Camera4
        else if (curTarget == targets[3])
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVerticle = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0.0f, moveVerticle, -moveHorizontal);

            curTarget.GetComponent<Rigidbody>().velocity = (movement * speed);

        }
    }
}
