using UnityEngine;

public class ForceRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            SpawnPoints.instance.StartCoroutine(SpawnPoints.instance.SpawnPlayer());
        }
    }
}
