using UnityEngine;

public class PlankPuzzle : MonoBehaviour
{

    [SerializeField] private Quaternion target;
    [SerializeField] private float speed;

    public bool MoveObject;

    void Update()
    {
        if (MoveObject)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, speed * Time.deltaTime);

    }
}
