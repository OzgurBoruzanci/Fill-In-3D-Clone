using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
        //MovementLimitControl();
        //MouseControl();
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * 10 * Time.deltaTime, Space.World);

    }

    void MovementLimitControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-5.5f), 5.5f);
        viewPos.z = Mathf.Clamp(viewPos.z, (-7f), 16f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 0);
        transform.position = viewPos;
    }

}
