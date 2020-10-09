using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{

    public Transform cam;
    public LayerMask layerMask;
    public Transform guide;
    /*
    Raycast from center of screen to a distance of x
    if ray != null and get key = e 
    boxtransform position = mouse position
    */
    void Start()
    {
        
    }

    void Update()
    {
        detectRay();
    }

    private void detectRay(){

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && Input.GetKeyDown(KeyCode.E)){
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("hit!");
            hit.collider.gameObject.transform.position = guide.position;
        }
        else{
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("No hit!");
        }


    }
}
