using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;
    GameObject mousePosition;
    Vector3 mouseWorldPosition;

    Transform destination;

    void Start()
    {
        mousePosition = new GameObject("MousePosition");
        mousePosition.transform.position= new Vector3(transform.position.x,0,transform.position.z+2);
        
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            

            MouseControl();
        }
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
        //movementDirection = transform.TransformDirection(movementDirection);
        movementDirection.Normalize();
        //transform.position += movementDirection * Time.deltaTime * 5f;
        transform.Translate(movementDirection * 5 * Time.deltaTime, Space.World);
        mousePosition.transform.Translate(movementDirection * 20 * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            mousePosition.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
        transform.LookAt(mousePosition.transform);


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
        Vector3 viewPosMouse = mousePosition.transform.position;
        viewPosMouse.x = Mathf.Clamp(viewPosMouse.x, (-5f), 5f);
        viewPosMouse.z = Mathf.Clamp(viewPosMouse.z, (-7f), 15f);
        viewPosMouse.y = Mathf.Clamp(viewPosMouse.y, 0, 0);
        mousePosition.transform.position = viewPosMouse;
    }
}
