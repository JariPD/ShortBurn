using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    [SerializeField] private MoveObjectPuzzle door;
    [SerializeField] private ParticleSystem particle;

    [Header("Settings")]
    public int AmountActive = 0;

    private Collider col;
    private bool coroutineAllowed = true;
    private float timer;

    private void Awake()
    {
        instance = this;

        col = GetComponent<SphereCollider>();
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
            //particle.Play();

            timer += Time.deltaTime;

            if (timer >= 0.1)
            {
                //plays sound effect
                AudioManager.instance.Play("Stone Door Opening");

                //open door to next area
                door.MoveObject = true;

                //screen shake to indicate something is moving
                StartCoroutine(CameraShake.instance.Shake(1.3f, 0.04f));
            }

            if (timer >= 4.8)
            {
                timer = 0;

                //moves player to next area
                MovePlayerToNextArea.instance.MovePlayer = true;

                //turns off collider so player cant go back in
                col.enabled = false;
            }
        }
    }
}
