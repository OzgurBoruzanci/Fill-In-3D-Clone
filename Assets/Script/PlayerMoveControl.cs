using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMoveControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    public float lerpRotateSpeed;

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementControl();
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
                if ((hitPoint - transform.position).magnitude > 1)
                {
                    rigidBody.velocity = (hitPoint - transform.position).normalized * speed;
                    transform.forward = Vector3.Lerp(transform.forward, (hitPoint - transform.position).normalized, lerpRotateSpeed * Time.deltaTime);
                }

            }
        }
    }
}
