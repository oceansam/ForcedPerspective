using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{

    public Transform cam;
    public LayerMask layerMask;
    public Transform guide;
    private bool attach;


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
            attach = true;
            setPosition(hit);

        }
        else{
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("No hit!");
        }

        if (attach){
            setPosition(hit);
        }
        else if (attach && Input.GetKeyDown(KeyCode.E)){
            resetPosition(hit);
            attach = false;
        }


    }

    void setPosition(RaycastHit hit){
        GameObject hittemp;
      
        hittemp = hit.collider.gameObject;
        hittemp.GetComponent<Rigidbody>().useGravity = false;
        hittemp.GetComponent<Rigidbody>().isKinematic = true;
        hittemp.transform.position = guide.position;
        hittemp.transform.rotation = guide.rotation;

        

    }

    void resetPosition(RaycastHit hit){
        GameObject hittemp;
    
        hittemp = hit.collider.gameObject;
        hittemp.GetComponent<Rigidbody>().useGravity = true;
        hittemp.GetComponent<Rigidbody>().isKinematic = false;
        hittemp.transform.position = guide.position;
        hittemp.transform.rotation = guide.rotation;
    }
}
