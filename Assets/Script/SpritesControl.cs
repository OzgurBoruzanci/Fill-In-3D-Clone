using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class SpritesControl : MonoBehaviour
{
    [SerializeField]
    private Texture2D image;

    [SerializeField]
    private GameObject imageObject;

    int worldX;
    int worldZ;
    int counter = 0;

    Color32[] pixels;
    List<GameObject> imageObjectList;
    List<GameObject> greyImageObjectList;
    Vector3[] spawnPositions;
    Vector3 startingSpawnPosition;
    Vector3 currentSpawnPosition;

    void Start()
    {
        imageObjectList = new List<GameObject>();
        greyImageObjectList = new List<GameObject>();
        worldX=image.width;
        worldZ=image.height;

        pixels = image.GetPixels32();

        CreateCloneImage();
        CloneImageControl();
        InstantiateImageColorControl();
        GreyImagePosition();
    }

    void CreateCloneImage()
    {
        spawnPositions = new Vector3[pixels.Length];
        startingSpawnPosition = new Vector3(-Mathf.Round(worldX / 2), 0, -Mathf.Round(worldZ / 2));
        currentSpawnPosition = startingSpawnPosition;

        for (int y = 0; y < worldZ; y++)
        {
            for (int x = 0; x < worldX; x++)
            {
                UnityEngine.Color pixelColor = image.GetPixel(x, y);
                spawnPositions[counter] = currentSpawnPosition;
                currentSpawnPosition.x++;
                GameObject cloneImage = Instantiate(imageObject, spawnPositions[counter], Quaternion.identity);
                GameObject cloneImageGrey = Instantiate(imageObject, spawnPositions[counter], Quaternion.identity);
                imageObjectList.Add(cloneImage);
                greyImageObjectList.Add(cloneImageGrey);
                cloneImage.transform.parent = transform;
                cloneImageGrey.transform.parent = transform;
                imageObjectList[counter].GetComponent<Renderer>().material.color = new UnityEngine.Color(pixelColor.r, pixelColor.g, pixelColor.b);
                counter++;
            }
            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }
    }

    void CloneImageControl()
    {
        for (int i = 0; i < imageObjectList.Count; i++)
        {
            imageObjectList[i].transform.position = new Vector3(imageObjectList[i].transform.position.x, imageObjectList[i].transform.position.y+0.01f, imageObjectList[i].transform.position.z+20);
            imageObjectList[i].GetComponent<MeshRenderer>().enabled= false;
            imageObjectList[i].AddComponent<ImageObjectControl>();
        }
    }
    void GreyImagePosition()
    {
        for (int i = 0; i < greyImageObjectList.Count; i++)
        {
            greyImageObjectList[i].transform.position = new Vector3(greyImageObjectList[i].transform.position.x, greyImageObjectList[i].transform.position.y, greyImageObjectList[i].transform.position.z + 20);
        }
    }

    void InstantiateImageColorControl()
    {
        for (int i = 0; i < imageObjectList.Count; i++)
        {
            if (imageObjectList[i].GetComponent<Renderer>().material.color == UnityEngine.Color.black)
            {
                Destroy(imageObjectList[i]);
                Destroy(greyImageObjectList[i]);
            }
        }
    }

}
