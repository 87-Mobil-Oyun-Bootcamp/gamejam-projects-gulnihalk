using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishCountUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI fishCountText;

    public System.Action GameStarted;
    public int fishCount;

    void Awake()
    {
        PlayMyAnimation.OnDoorOpened += PlayMyAnimation_OnDoorOpened;
    }

    void OnDisable()
    {
        PlayMyAnimation.OnDoorOpened -= PlayMyAnimation_OnDoorOpened;
    }

    void PlayMyAnimation_OnDoorOpened()
    {
        fishCount++;
        if (fishCount == 1)
        {
            GameStarted?.Invoke();
        }

        fishCountText.SetText(fishCount.ToString());
    }
}
