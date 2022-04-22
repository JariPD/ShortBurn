using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeIndex : MonoBehaviour
{
    public static runeIndex instance;

    public int runeIndexx;

    private void Awake()
    {
        instance = this;
    }
}
