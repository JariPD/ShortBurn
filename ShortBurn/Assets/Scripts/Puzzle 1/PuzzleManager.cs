using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int AmountActive = 0;
    [SerializeField] private MoveObjectPuzzle door;
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

        //open door to next area
        door.MoveObject = true;

        //turn on text that say "Go to the middle of the circle"
        //launch player towards door

        yield return null;
    }
}
