using System.Collections;
using UnityEngine;

public class MoveObjectPuzzle : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float moveSpeed;
    private Vector3 resetPos;

    public bool MoveObject;
    public bool ResetDoor;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        resetPos = transform.localPosition;
    }

    void Update()
    {
        if (gameObject.CompareTag("Brick") && MoveObject)
        {
            AudioManager.instance.Play("Brick Puzzle");

            //if (Vector3.Distance(transform.position, targetPos) <= 0.01f)
            //bool a = Mathf.Approximately(transform.position.z, targetPos.z);

            if (transform.localPosition == targetPos)
                AudioManager.instance.Stop("Brick Puzzle");
        }

        if (MoveObject)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRot, rotSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
        else if (ResetDoor)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, resetPos, moveSpeed * Time.deltaTime);
        }
    }
}
