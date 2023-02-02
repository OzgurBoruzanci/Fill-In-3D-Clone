using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMoveControl : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;
    public float moveSpeed = 0.1f;
    Vector3 nextPosition;
    Ray ray;
    RaycastHit raycastHit;

    void Start()
    {

    }

    

    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out raycastHit);
            nextPosition = raycastHit.point;
            nextPosition.y= 0;
            transform.LookAt(nextPosition);
            transform.position=Vector3.MoveTowards(transform.position, nextPosition, moveSpeed);
            
        }
        if (transform.position== nextPosition)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }
        MoveControl();
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * 10 * Time.deltaTime, Space.World);
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
        viewPos.x = Mathf.Clamp(viewPos.x, (-17.5f), 17.5f);
        viewPos.z = Mathf.Clamp(viewPos.z, (-59.5f), 28.5f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 0);
        transform.position = viewPos;
    }
}
