using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBox : MonoBehaviour
{
    bool setActiveBool = true;

    //private void OnEnable()
    //{
    //    EventManager.FinishControl += FinishControla;
    //}
    //private void OnDisable()
    //{
    //    EventManager.FinishControl -= FinishControla;
    //}
    //void FinishControla()
    //{
    //    if (setActiveBool == false)
    //    {
    //        this.gameObject.SetActive(false);

    //    }
    //}

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
            SmallBoxControl();
            //EventManager.FinishControl();
        }
    }
    void SmallBoxControl()
    {
        if (setActiveBool == false)
        {
            this.gameObject.SetActive(false);

        }
    }

}
