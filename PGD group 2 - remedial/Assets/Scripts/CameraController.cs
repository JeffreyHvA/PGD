using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed;
    public float movementTime;
    public Vector3 newPos;
    
    public Quaternion newRotation;
    public float rotationAmount;

    public Vector3 zoomAmount;
    public Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
        {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPos += (transform.forward * movementSpeed);
        }
         if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPos += (transform.forward * -movementSpeed);
        }
         if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPos += (transform.right * -movementSpeed);
        }
         if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPos += (transform.right * movementSpeed);
        }

//Rotation
          if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
          if(Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

//Zoom
 if(Input.GetKey(KeyCode.Z))
        {
            newZoom += zoomAmount;
        }

if(Input.GetKey(KeyCode.X))
        {
            newZoom -= zoomAmount;
        }

//To get smooth movement
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime *movementTime);
    }
}

