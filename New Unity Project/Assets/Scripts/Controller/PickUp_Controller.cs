using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{

    public Transform cam;
    public LayerMask layerMask;
    public Transform guide;
    private bool attach = false;
    


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
        bool raycastCheck = Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);
        if (raycastCheck){

            if (attach && Input.GetKeyDown(KeyCode.Q)){
                attach = false;
                resetPosition(hit);
                
            
            }

            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("hit!");
            
            if (!attach && Input.GetKeyDown(KeyCode.E)){
                attach = true;
                setPosition(hit);

            }

        }
        else{
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("No hit!");
        }

        



    }

    void setPosition(RaycastHit hit){
        GameObject hittemp;
      
        hittemp = hit.collider.gameObject;
        
        hittemp.GetComponent<Rigidbody>().useGravity = false;
        hittemp.GetComponent<Rigidbody>().isKinematic = true;
        hittemp.transform.position = guide.position;
        hittemp.transform.rotation = guide.rotation;
        hittemp.transform.parent = guide.transform;

        

    }

    void resetPosition(RaycastHit hit){
        GameObject hittemp;
    
        hittemp = hit.collider.gameObject;
        hittemp.GetComponent<Rigidbody>().useGravity = true;
        hittemp.GetComponent<Rigidbody>().isKinematic = false;
        hittemp.transform.parent = null;
        
    }

    
}
