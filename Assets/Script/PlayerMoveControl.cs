using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMoveControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; /*suggestion for MovementControl speed=15f*/
    public float lerpRotateSpeed=10; /*suggestion for MovementControl lerpRotateSpeed=30f*/

    float horizontal;
    float vertical;

    bool canMove = true;

    Rigidbody rigidBody;
    public DynamicJoystick dynamicJoystick;
    Vector3 joystickPos;
    Vector3 direction;

    private void OnEnable()
    {
        EventManager.GameFinishControl += GameFinishControl;
    }
    private void OnDisable()
    {
        EventManager.GameFinishControl -= GameFinishControl;
    }

    void GameFinishControl()
    {
        canMove= false;
    }

    void Awake()
    {
        //rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //MovementControl();
        if (Input.GetMouseButton(0) && canMove)
        {
            JoystickControl();
        }
        PlayerPosMoveControl();
    }

    void MovementControl()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                if ((hitPoint - transform.position).magnitude > 0.5f)
                {
                    rigidBody.velocity = (hitPoint - transform.position).normalized * speed;
                    transform.forward = Vector3.Lerp(transform.forward, (hitPoint - transform.position).normalized, lerpRotateSpeed * Time.deltaTime);

                }

            }
        }
        else /*if (Input.GetMouseButtonUp(0))*/
        {
            
            rigidBody.velocity= (transform.position).normalized * 0.1f;
            transform.forward = Vector3.Lerp(transform.forward, (transform.position).normalized, 0 );
        }
    }

    void JoystickControl()
    {
        horizontal = dynamicJoystick.Horizontal;
        vertical=dynamicJoystick.Vertical;
        joystickPos=new Vector3(horizontal*speed*Time.deltaTime,0,vertical*speed*Time.deltaTime);
        transform.position += joystickPos;

        direction= Vector3.forward*vertical+Vector3.right*horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), lerpRotateSpeed * Time.deltaTime);

        
    }

    void PlayerPosMoveControl()
    {
        Vector3 viewPosMouse = transform.position;
        viewPosMouse.x = Mathf.Clamp(viewPosMouse.x, (-3.8f), 3.8f);
        viewPosMouse.z = Mathf.Clamp(viewPosMouse.z, (-16.15f), 1.35f);
        viewPosMouse.y = Mathf.Clamp(viewPosMouse.y, 0.5f, 0.5f);
        transform.position = viewPosMouse;
    }
}
