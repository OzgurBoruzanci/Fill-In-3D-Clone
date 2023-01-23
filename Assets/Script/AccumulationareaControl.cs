using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulationareaControl : MonoBehaviour
{
    List<GameObject> pieceList;
    GameObject pieceClone;
    Vector3 cubesPivot;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    void Start()
    {
        pieceList = new List<GameObject>();
    }
    private void OnEnable()
    {
        EventManager.FinishControl += FinishControl;
    }
    private void OnDisable()
    {
        EventManager.FinishControl -= FinishControl;
    }
    void FinishControl()
    {

    }

    void Update()
    {
        if (pieceList.Count==8)
        {
            EventManager.FinishControl();
            Debug.Log("ggg");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Cube")
        {
            pieceList.Add(collision.gameObject);
        }
    }
    

    
}
