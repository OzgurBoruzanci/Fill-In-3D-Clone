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
    private void LateUpdate()
    {
        MoveControl();
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector3 vec = new Vector3(horizontal, 0, vertical);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 5f;
        
        
    }
    void PlayerRotation()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToViewportPoint(mousePos);

        Vector3 distance = transform.position - mousePos;
        distance.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distance), 0.5f);

    }
    void MoveControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-3.7f), 3.7f);
        viewPos.z = Mathf.Clamp(viewPos.z, (-4.65f), 13.6f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 0);
        transform.position = viewPos;
    }
}
