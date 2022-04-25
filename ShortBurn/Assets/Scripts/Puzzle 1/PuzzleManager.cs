using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;


    public int AmountActive = 0;
    private bool allowedToRunCourotine = true;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (AmountActive >= 5 && allowedToRunCourotine)
            StartCoroutine(Win());
    }

    IEnumerator Win()
    {
        allowedToRunCourotine = false;

        print("Puzzle complete");

        yield return null;
    }
}
