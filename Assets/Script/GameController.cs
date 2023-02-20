using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.GameFinishControl += GameFinishControl;
    }
    private void OnDisable()
    {
        EventManager.GameFinishControl -= GameFinishControl;
    }

    void GameFinishControl()
    {
        Debug.Log("************ GAME FINISH ****************");
    }
}
