using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObjectControl : MonoBehaviour
{
    public bool isCollisionActive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.GetComponent<ImageBoxController>() && isCollisionActive && collision.gameObject.GetComponent<ImageBoxController>().isCollision)
            {
                collision.gameObject.GetComponent<ImageBoxController>().isCollision = false;
                isCollisionActive = false;
                transform.GetComponent<MeshRenderer>().enabled = true;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
