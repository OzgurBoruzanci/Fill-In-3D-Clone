using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class IllustraredBoxCreator : MonoBehaviour
{
    [SerializeField]
    private Texture2D image;

    [SerializeField]
    private GameObject imageBox;

    int worldX;
    int worldZ;
    int counter = 0;
    float xPos = -6;
    float yPos = 0.5f;
    float zPos = -23;

    Color32[] pixels;
    List<GameObject> imageBoxList;
    Vector3[] spawnPositions;
    Vector3 startingSpawnPosition;
    Vector3 currentSpawnPosition;

    void Start()
    {
        imageBoxList = new List<GameObject>();
        worldX = image.width;
        worldZ = image.height;

        pixels = image.GetPixels32();

        CreateImageBox();
        ImageBoxControl();
        ImageBoxColorControl();
        ImageBoxPosition();
    }

    void CreateImageBox()
    {
        spawnPositions = new Vector3[pixels.Length];
        startingSpawnPosition = new Vector3(-Mathf.Round(worldX / 2), 0.5f, -Mathf.Round(worldZ / 2));
        currentSpawnPosition = startingSpawnPosition;

        for (int y = 0; y < worldZ; y++)
        {
            for (int x = 0; x < worldX; x++)
            {
                UnityEngine.Color pixelColor = image.GetPixel(x, y);
                spawnPositions[counter] = currentSpawnPosition;
                currentSpawnPosition.x++;
                GameObject cloneBox = Instantiate(imageBox, spawnPositions[counter], Quaternion.identity);
                imageBoxList.Add(cloneBox);
                cloneBox.transform.parent = transform;
                imageBoxList[counter].GetComponent<Renderer>().material.color = new UnityEngine.Color(pixelColor.r, pixelColor.g, pixelColor.b);
                counter++;
            }
            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }
    }

    void ImageBoxControl()
    {
        for (int i = 0; i < imageBoxList.Count; i++)
        {
            imageBoxList[i].transform.position = new Vector3(imageBoxList[i].transform.position.x, imageBoxList[i].transform.position.y, imageBoxList[i].transform.position.z - 20);
            imageBoxList[i].AddComponent<Rigidbody>();
            imageBoxList[i].GetComponent<Rigidbody>().mass = 0f;
            imageBoxList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void ImageBoxPosition()
    {
        #region stack
        //for (int i = 0; i < imageBoxList.Count; i++)
        //{
        //    imageBoxList[i].transform.position = new Vector3(xPos, yPos, zPos);
        //    xPos++;
        //    if (xPos == 4)
        //    {
        //        xPos = -6;
        //        yPos++;
        //        if (yPos == 6.5f)
        //        {
        //            yPos = 0.5f;
        //            zPos++;
        //        }
        //    }
        //}
        #endregion

        #region in-line
        //for (int i = 0; i < imageBoxList.Count; i++)
        //{
        //    imageBoxList[i].transform.position = new Vector3(xPos, yPos, zPos);
        //    zPos++;
        //    if (zPos == 5)
        //    {
        //        zPos = -23;
        //        xPos=xPos+2;
        //        if (xPos == 6f)
        //        {
        //            xPos = -6f;
        //            //zPos++;
        //        }
        //    }
        //}
        #endregion
    }

    void ImageBoxColorControl()
    {
        for (int i = 0; i < imageBoxList.Count; i++)
        {
            if (imageBoxList[i].GetComponent<Renderer>().material.color == UnityEngine.Color.black)
            {
                Destroy(imageBoxList[i]);
            }
        }
    }
}
