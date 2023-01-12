using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
            PlayerRotation();
        }
        //PlayerRotation();
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector3 vec = new Vector3(horizontal, 0, vertical);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 10f;
        
        
    }
    void PlayerRotation()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);

        Vector3 distance = transform.position - mousePos;
        distance.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distance), 0.3f);

    }
}
