using System.Collections;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public static SpawnPoints instance;

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;

    [Header("Settings")]
    public int CheckPoint = 1;
    [SerializeField] private Transform[] spawnPoints;

    private Transform currentSpawnPoint;
    private float respawnTimer = 3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentSpawnPoint = spawnPoints[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(SpawnPlayer());

        //if statement to check where to respawn the player
        if (CheckPoint == 2)
            currentSpawnPoint = spawnPoints[1];

        if (CheckPoint == 3)
            currentSpawnPoint = spawnPoints[2];
    }

    public IEnumerator SpawnPlayer()
    {
        //turn off player movement, mouselook and sway script
        LockPlayer.instance.fpsController.enabled = false;
        LockPlayer.instance.mouseLook.enabled = false;
        LockPlayer.instance.sway.enabled = false;

        //starts playing the fade animation
        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(respawnTimer);

        //turn on player movement, mouselook and sway script
        LockPlayer.instance.fpsController.enabled = true;
        LockPlayer.instance.mouseLook.enabled = true;
        LockPlayer.instance.sway.enabled = true;

        //sets players new position
        player.transform.position = currentSpawnPoint.position;
    }
}
