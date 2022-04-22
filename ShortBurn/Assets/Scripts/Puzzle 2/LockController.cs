using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    private int[] result, correctCombination;

    void Start()
    {
        result = new int[] { 5, 5, 5 };
        correctCombination = new int[] { 6, 6, 6 };
        Rotater.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = number;
                break;

            case "wheel2":
                result[1] = number;
                break;

            case "wheel3":
                result[2] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            print("Puzzle Complete");
        }
    }

    private void OnDestroy()
    {
        Rotater.Rotated -= CheckResults;
    }

}
