using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpritesControl : MonoBehaviour
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
        boxList= new List<GameObject>();
        worldX=image.width;
        worldZ=image.height;

        Debug.Log(worldX + " xxx" + worldZ);

        pixels = image.GetPixels32();

        spawnPositions = new Vector3[pixels.Length];
        startingSpawnPosition=new Vector3(-Mathf.Round(worldX/2),0,-Mathf.Round(worldZ/2));
        currentSpawnPosition=startingSpawnPosition;

        //for (int z = 0; z < worldX; z++)
        //{
        //    for (int x = 0; x < worldZ; x++)
        //    {
        //        spawnPositions[counter] = currentSpawnPosition;
        //        counter++;
        //        currentSpawnPosition.x++;
        //    }
        //    currentSpawnPosition.x=startingSpawnPosition.x;
        //    currentSpawnPosition.z++;
        //}

        counter = 0;
        for (int y = 0; y < worldZ; y++)
        {
            for (int x = 0; x < worldX; x++)
            {
                Color pixelColor = image.GetPixel(x, y);
                Debug.Log(pixelColor);
                spawnPositions[counter] = currentSpawnPosition;
                currentSpawnPosition.x++;
                //colorList.Add(pixelColor);
                GameObject cloneBox=Instantiate(box, spawnPositions[counter], Quaternion.identity);
                boxList.Add(cloneBox);
                boxList[counter].GetComponent<Renderer>().material.color = new Color(pixelColor.r, pixelColor.g, pixelColor.b);
                counter++;
            }
            currentSpawnPosition.x = startingSpawnPosition.x;
            currentSpawnPosition.z++;
        }
        

        //counter = 0;
        //foreach (Vector3 pos in spawnPositions)
        //{
        //    boxList[counter].transform.position = pos;
        //    //Color pixelColor = pixels[counter];
        //    //Instantiate(box, pos, Quaternion.identity);
        //    //boxList.Add(box);
        //    //box.GetComponent<Renderer>().material.color = pixelColor;
        //    counter++;
        //}
    }

}
