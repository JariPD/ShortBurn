using System.Collections;
using UnityEngine;

public class MoveObjectPuzzle : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float moveSpeed;

    public bool MoveObject;

    void Update()
    {
        if (gameObject.CompareTag("Brick") && MoveObject)
            StartCoroutine(StartSFX());
      

        if (MoveObject)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRot, rotSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator StartSFX()
    {
        AudioManager.instance.Play("Brick Puzzle");

        yield return new WaitForSeconds(1.3f);

        AudioManager.instance.Stop("Brick Puzzle");
    }
}
