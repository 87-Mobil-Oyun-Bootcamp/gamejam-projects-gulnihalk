using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSwipe : MonoBehaviour
{
    [SerializeField]
    private Animator hand;

    [Space]
    [SerializeField]
    FishCountUI fishCountUI;

    private void Awake()
    {
        fishCountUI.GameStarted += StopSwipeAnim;
    }

    void StopSwipeAnim()
    {
        hand.gameObject.SetActive(false);
    }
    
}
