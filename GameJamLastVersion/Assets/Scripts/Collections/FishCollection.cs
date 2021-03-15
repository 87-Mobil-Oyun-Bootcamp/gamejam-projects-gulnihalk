using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollection : MonoBehaviour
{
    List<Transform> fishes = new List<Transform>();

    void OnValidate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            fishes.Add(transform.GetChild(i));
        }
    }
}
