using UnityEngine;

public class LockController : MonoBehaviour
{
    private int[] result, correctCombination;

    void Start()
    {
        //sets the starting combination
        result = new int[] { 5, 5, 5 };

        //sets the correct combination
        correctCombination = new int[] { 6, 6, 6 };

        //checks results
        Rotater.Rotated += CheckResults;
    }

    /// <summary>
    /// Function to check for lock results
    /// </summary>
    /// <param name="wheelName"></param>
    /// <param name="number"></param>
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

        //checks if the combination is correct
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            print("Puzzle Complete");

            //do something
        }
    }

    private void OnDestroy()
    {
        Rotater.Rotated -= CheckResults;
    }

}
