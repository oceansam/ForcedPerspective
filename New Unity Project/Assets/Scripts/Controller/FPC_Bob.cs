using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC_Bob : MonoBehaviour
{

    
    public FirstPerson_Controller controller;
    float defaultPosition = 0;
    public float bobSpeed = 0.15f;
    private float timeShift = 0;

    void Start()
    {
        defaultPosition = transform.localPosition.y;
    }

    // transform local position y + sin of timer
    void Update()
    {
        
        if (Mathf.Abs(controller.moveVelocity.x) > 0 || Mathf.Abs(controller.moveVelocity.z) > 0){


            transform.localPosition = new Vector3(0, defaultPosition + Mathf.Sin(timeShift) * bobSpeed, 0);
            
            timeShift += Time.deltaTime + bobSpeed;


        }

    }
}
