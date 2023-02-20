using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObjectControl : MonoBehaviour
{
    public bool isCollisionActive = true;
    Color pixelColor;

    private void Awake()
    {
        pixelColor=this.GetComponent<Renderer>().material.color;
    }
    private void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.gray;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.GetComponent<ImageBoxController>() && isCollisionActive && other.gameObject.GetComponent<ImageBoxController>().isCollision)
            {
                this.GetComponent<Renderer>().material.color=pixelColor;
                other.gameObject.GetComponent<ImageBoxController>().isCollision = false;
                isCollisionActive = false;
                //transform.GetComponent<MeshRenderer>().enabled = true;
                Destroy(other.gameObject);
            }
        }
    }
}
