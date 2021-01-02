using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PickUp_Controller : MonoBehaviour
{

    public Transform cam;
    public LayerMask layerMask;
    public Transform guide;
    private bool attach = false;
    private bool activate = false;



    void Start()
    {
        
    }

    void Update()
    {
        detectRay();

    }

    /*
    detectRay

    Casts a infinite ray that detects on a specified layermask for interactable objects. 
    */
    private void detectRay(){

        RaycastHit hit;
        
        bool raycastCheck = Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);
        if (raycastCheck){

            if (attach && Input.GetKeyDown(KeyCode.G) && !activate){
                Debug.Log("PUSH!");
                activate = true;
                AngularDiameter(hit);
        }
            if (attach && Input.GetKeyDown(KeyCode.Q)){
                Debug.Log("DROP!");

                attach = false;
                resetPosition(hit);
                activate = false;
            
            }

            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            if (!attach && Input.GetKeyDown(KeyCode.E)){
                Debug.Log("PICK!");
                attach = true;
                setPosition(hit);
                
            }

        }
        else{
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        



    }
    /*
    SetPosition

    Takes a raycast hit information and freezes gravity and enabeling its kinematic componenet. 
    The gameobject is placed towards a guide represented as the location at which the gameobject will be held. 
    */
    void setPosition(RaycastHit hit){
        GameObject hittemp;
      
        hittemp = hit.collider.gameObject;
        
        hittemp.GetComponent<Rigidbody>().useGravity = false;
        hittemp.GetComponent<Rigidbody>().isKinematic = true;
        hittemp.transform.position = guide.position;
        hittemp.transform.rotation = guide.rotation;
        hittemp.transform.parent = guide.transform;
        

    }
    /*
    resetPosition

    Reverts the operations done in setPosition() and deparents the gameObject.
    */
    void resetPosition(RaycastHit hit){
        GameObject hittemp;
    
        hittemp = hit.collider.gameObject;
        hittemp.GetComponent<Rigidbody>().useGravity = true;
        hittemp.GetComponent<Rigidbody>().isKinematic = false;
        hittemp.transform.parent = null;
        
    }

    // Angular Diameter

    void AngularDiameter(RaycastHit hit){

        GameObject hittemp;
        hittemp = hit.collider.gameObject;
        
        // Angular Diameter
        // double distance = (hittemp.transform.position - cam.transform.position).magnitude;
        // double diameter = hittemp.transform.localScale.magnitude;
        // double angularDiam = Math.Atan(diameter/2*distance);

        // GameObject's distance from Camera is hardcoded at 3
        hittemp.transform.position += cam.transform.TransformDirection(Vector3.forward).normalized * 3;

        // As we double the initial distance (previously 3) We scaleup the object by this factor
        hittemp.transform.localScale *= 2;

    }
}
