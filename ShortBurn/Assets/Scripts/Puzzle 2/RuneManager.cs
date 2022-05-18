using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public static RuneManager instance;

    public int AmountPressed;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (AmountPressed == 5)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        //play win cutscene

        print("Win");

        yield return null;
    }

}
