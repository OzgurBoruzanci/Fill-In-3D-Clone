using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragmentation : MonoBehaviour
{
    List<GameObject> pieceList;
    List<GameObject> pieceSetActiveFalseList;
    GameObject piece;
    Rigidbody rb;
    Collider[] colliders;
    Vector3 fragmentationPos;
    Vector3 cubesPivot;

    bool fragmentationBool = true;

    float cubesPivotDistance;
    public float cubeSize = 0.2f;
    public float fragmentationRadius = 4;
    public float fragmentationForce = 50;
    public float fragmentationUpward = 0.4f;
    public int cubesInRow = 5;


    private void OnEnable()
    {
        EventManager.FnishControl += FnishControl;
    }
    private void OnDisable()
    {
        EventManager.FnishControl -= FnishControl;
    }
    void FnishControl()
    {
        //this.transform.position = new Vector3(0, 0.1f, 12);
        //this.gameObject.SetActive(true);
        pieceSetActiveFalseList.Add(piece.gameObject);
        if (pieceList.Count == pieceSetActiveFalseList.Count)
        {
            this.transform.position = new Vector3(0, 0.1f, 12);
            this.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        pieceList= new List<GameObject>();
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor" && fragmentationBool==true)
        {
            FragmentationCube();
            fragmentationBool= false;
        }
    }

    void FragmentationCube()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        fragmentationPos = transform.position;
        colliders = Physics.OverlapSphere(fragmentationPos, fragmentationRadius);
        foreach (Collider hit in colliders)
        {
            rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fragmentationForce, transform.position, fragmentationRadius, fragmentationUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot + new Vector3(0, 0.5f, 0);
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<SmallBox>();
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        pieceList.Add(piece.gameObject);
    }

}
