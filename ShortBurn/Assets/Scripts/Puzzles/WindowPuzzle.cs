using UnityEngine;

public class WindowPuzzle : MonoBehaviour
{
    public bool CloseWindow;

    [Header("References")]
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject trigger;

    [Header("Settings")]
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float moveSpeed;


    void Update()
    {
        if (CloseWindow)
        {
            window.transform.localPosition = Vector3.MoveTowards(window.transform.localPosition, targetPos, moveSpeed * Time.deltaTime);

            rope.SetActive(false);
            trigger.SetActive(false);
        }
    }
}