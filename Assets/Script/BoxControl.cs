using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{

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
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(0.3f, 2.6f, 12);
        Debug.Log("a");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
