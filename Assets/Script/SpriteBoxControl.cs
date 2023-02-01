using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpriteBoxControl : MonoBehaviour
{
    [SerializeField]
    private Texture2D image;

    [SerializeField]
    private GameObject box;

    int worldX;
    int worldZ;
    int counter = 0;

    Color32[] pixels;
    List<GameObject> boxList;
    Vector3[] spawnPositions;
    Vector3 startingSpawnPosition;
    Vector3 currentSpawnPosition;

    void Start()
    {
        boxList = new List<GameObject>();
        worldX = image.width;
        worldZ = image.height;

        pixels = image.GetPixels32();

        CreateCloneBox();
        CloneBoxPosition();
        CloneBoxColorControl();
    }

    void CreateCloneBox()
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
                GameObject cloneBox = Instantiate(box, spawnPositions[counter], Quaternion.identity);
                boxList.Add(cloneBox);
                cloneBox.transform.parent = transform;
                boxList[counter].GetComponent<Renderer>().material.color = new UnityEngine.Color(pixelColor.r, pixelColor.g, pixelColor.b);
                counter++;
            }
            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }
    }

    void CloneBoxPosition()
    {
        for (int i = 0; i < boxList.Count; i++)
        {
            boxList[i].transform.position = new Vector3(boxList[i].transform.position.x, boxList[i].transform.position.y, boxList[i].transform.position.z - 20);
            boxList[i].AddComponent<Rigidbody>();
            boxList[i].GetComponent<Rigidbody>().mass = 0f;
            boxList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void CloneBoxColorControl()
    {
        for (int i = 0; i < boxList.Count; i++)
        {
            if (boxList[i].GetComponent<Renderer>().material.color== UnityEngine.Color.black)
            {
                Destroy(boxList[i]);
            }
        }
    }
}
