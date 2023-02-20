using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBoxController : MonoBehaviour
{
    public bool isCollision = true;

    private void Update()
    {
        ImageBoxMoveControl();
    }

    void ImageBoxMoveControl()
    {
        Vector3 viewPosMouse = transform.position;
        viewPosMouse.x = Mathf.Clamp(viewPosMouse.x, (-4.76f), 4.76f);
        viewPosMouse.z = Mathf.Clamp(viewPosMouse.z, (-16.10f), 3.17f);
        viewPosMouse.y = Mathf.Clamp(viewPosMouse.y, 0.125f, 2.5f);
        transform.position = viewPosMouse;
    }
}
