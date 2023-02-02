using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObjectControl : MonoBehaviour
{
    bool isCollisionActive = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag !="Player")
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == this.gameObject.GetComponent<MeshRenderer>().material.color && isCollisionActive == true)
            {
                isCollisionActive = false;
                transform.GetComponent<MeshRenderer>().enabled = true;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
