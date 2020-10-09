using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{

    public Transform guide;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void setObjectPlace(){
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;

        //sets the object infront of us relative to our "guide" game object
        this.transform.position = guide.position;
        this.transform.rotation = guide.rotation;


    }

    void dropObject(){
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;

        //sets the object infront of us relative to our "guide" game object
        this.transform.position = guide.position;
    }
}
