using UnityEngine;

public class PathTest : MonoBehaviour
{
    [SerializeField] private Vector3 target;
    [SerializeField] private float speed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
