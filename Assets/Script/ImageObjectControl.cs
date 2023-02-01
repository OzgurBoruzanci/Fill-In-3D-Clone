using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObjectControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>().material.color==this.gameObject.GetComponent<MeshRenderer>().material.color && collision.gameObject.tag!="Player")
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            collision.gameObject.SetActive(false);
        }
    }
}
