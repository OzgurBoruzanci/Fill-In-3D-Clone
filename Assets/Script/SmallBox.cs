using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBox : MonoBehaviour
{
    bool setActiveBool = true;

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
        if (setActiveBool==false)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Accumulation")
        {
            setActiveBool= false;
            EventManager.FnishControl();
        }
    }

}
