using UnityEngine;

public class BoilingPuzzle : MonoBehaviour
{
    public bool LaunchPlayer;

    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject player;
    void Update()
    {
        if(LaunchPlayer)
        {
            LockPlayer.instance.FpsController.enabled = false;

            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        if (player.transform.position == targetPos)
        {
            LaunchPlayer = false;

            LockPlayer.instance.FpsController.enabled = true;
        }
    }
}
