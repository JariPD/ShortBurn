using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int AmountActive = 0;
    private bool coroutineAllowed = true;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //win condition
        if (AmountActive >= 5 && coroutineAllowed)
            StartCoroutine(Win());
    }

    IEnumerator Win()
    {
        coroutineAllowed = false;

        print("Puzzle complete");

        //do something

        yield return null;
    }
}
