using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    [SerializeField] private CameraShake camShake;

    [Header("Settings")]
    public int AmountActive = 0;
    [SerializeField] private MoveObjectPuzzle door;


    private bool coroutineAllowed = true;
    private float timer;

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

        //screen shake to indicate something is moving
        StartCoroutine(camShake.Shake(5.4f, 0.015f));

        //set the next checkpoint for respawning
        SpawnPoints.instance.CheckPoint += 1;

        //turn on text that say "Go to the middle of the circle"
        UIManager.instance.Puzzle1Win();

        yield return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("player") && AmountActive == 5)
        {
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                timer = 0;
                MovePlayerToNextArea.instance.MovePlayer = true;
            }
        }
    }
}
