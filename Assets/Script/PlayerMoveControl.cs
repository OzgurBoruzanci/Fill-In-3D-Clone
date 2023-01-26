using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;
    public GameObject movementObject;
    //GameObject mousePosition;
    //Vector3 mouseWorldPosition;

    //Transform destination;

    void Start()
    {
        //mousePosition = new GameObject("MousePosition");
        //mousePosition.transform.position= new Vector3(transform.position.x,0,transform.position.z+2);
        

    }

    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
        transform.LookAt(movementObject.transform);
    }
    private void LateUpdate()
    {
        MoveControl();
        MousePosMoveControl();
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * 5 * Time.deltaTime, Space.World);
        
        //mousePosition.transform.Translate(movementDirection * 20 * Time.deltaTime, Space.World);

        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    mousePosition.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        //}

        //transform.LookAt(movementObject.transform);


    }
    
    void MoveControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-3.7f), 3.7f);
        viewPos.z = Mathf.Clamp(viewPos.z, (-4.65f), 13.6f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 0);
        transform.position = viewPos;
    }
    void MousePosMoveControl()
    {
        Vector3 viewPosMouse = movementObject.transform.position;
        viewPosMouse.x = Mathf.Clamp(viewPosMouse.x, (transform.position.x - 1f), transform.position.x +1f);
        viewPosMouse.z = Mathf.Clamp(viewPosMouse.z, (transform.position.z - 1f), transform.position.z+ 1f);
        viewPosMouse.y = Mathf.Clamp(viewPosMouse.y, 0, 0);
        movementObject.transform.position = viewPosMouse;
    }
}
