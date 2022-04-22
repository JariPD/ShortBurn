using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotater : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    void Start()
    {
        coroutineAllowed = true;
        numberShown = 5;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateWheel());
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(-3.25f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown++;

        if (numberShown > 9)
            numberShown = 0;

        Rotated(name, numberShown);
    }
}
