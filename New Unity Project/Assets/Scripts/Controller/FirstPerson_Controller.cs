using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson_Controller : MonoBehaviour
{
    
    public Transform cam = null;

    [Range(0f, 5f)]
    public float camSpeed = 0.5f;

    [Range(0f, 5.0f)]
    public float moveSpeed = 5.0f;

    public float cameraPitch = 0.0f;

    public float gravity_Val = -10.0f;

    public bool lockCursor;
    public Vector3 moveVelocity;
    private CharacterController characterController;

    void Start()
    {
        lockCursor = true;
        characterController = gameObject.GetComponent<CharacterController>();

    }



    void Update()
    {
        cursorUpdateLock();
        UpdateMovement();
        UpdateMouseLook();
    }

    /*
    UpdateMouseLock()

    Controls the mouse input and translates to camera position/rotiation
    */
    void UpdateMouseLook(){

        // Get mouse space on screen and convert to input axis
        Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Degree of rotation with mouseDir.y (-= because x rotiation is inverted)
        cameraPitch -= mouseDir.y * camSpeed;

        // Clamp camera rotation to +90 and -90 to prevent infinite rotation
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        // Rotation in degrees relative to parent transform (preserves parent objects forward vector)
        cam.localEulerAngles = Vector3.right * cameraPitch;

        // Rotate transform in the horizontal
        transform.Rotate(Vector3.up * mouseDir.x * camSpeed);
    
    }

    /*
    UpdateMovement()

    Update the movement off our WASD input and normalize the vector to be applied on charactercontroller
    */
    void UpdateMovement(){


        // Store both horizontal and vertical input as a vector
        Vector3 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Normalize the vector (Case of b = 1, h = 1 and hypot = root(2), we move at a 1.41 speed therefore
        //                       therefore faster than our original 1)
        moveDir.Normalize();


        // Apply the move velocity relative to vectors
        if (Input.GetKey(KeyCode.LeftShift)){
            moveSpeed = 10.0f;
            moveVelocity = (transform.forward * moveDir.y + transform.right * moveDir.x) * moveSpeed * Time.deltaTime;
            
        }
        else{
            moveSpeed = 5.0f;
            moveVelocity = (transform.forward * moveDir.y + transform.right * moveDir.x) * moveSpeed * Time.deltaTime;

        }

        // Apply to character controller with respect to Time (fps issue)
        moveVelocity.y += gravity_Val * Time.deltaTime;
        characterController.Move(moveVelocity);
  
            

    }

    /*
    cursorUpdateLock()

    Centers and visually disables cursor
    */
    void cursorUpdateLock(){
        // Disable Cursor and Lock in place
        if (lockCursor){
            Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }
    }



}
