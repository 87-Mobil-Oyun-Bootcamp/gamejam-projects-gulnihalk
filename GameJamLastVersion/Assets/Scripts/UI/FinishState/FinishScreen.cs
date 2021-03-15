using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{  
    [Space]
    [SerializeField]
    MovePlayer movePlayer;

    GameObject fishCounter;

    private void Awake()
    {
        fishCounter = GameObject.Find("Canvas");
        movePlayer.Finished += ShowFinishScreen;
        float fishNum = movePlayer.forwardSpeed;
    }

    void ShowFinishScreen()
    {
        fishCounter.SetActive(false);
    }
}
