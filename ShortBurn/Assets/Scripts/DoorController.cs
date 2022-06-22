using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float moveSpeed;
    private Vector3 resetPos;

    public bool MoveObject;
    public bool ResetDoor;


    private void Start()
    {
        resetPos = transform.localPosition;
    }

    void Update()
    {
        if (MoveObject)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        else if (ResetDoor)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, resetPos, moveSpeed * Time.deltaTime);

        if (transform.localPosition == targetPos)
            AudioManager.instance.Stop("Stone Door Opening");

        if (transform.localPosition == resetPos && ResetDoor)
            AudioManager.instance.Stop("Stone Door Opening");
    }
}
