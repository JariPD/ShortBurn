using UnityEngine;

public class WindowPuzzle : MonoBehaviour
{
    public bool CloseWindow;

    [Header("References")]
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject trigger;

    [Header("Settings")]
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float moveSpeed;


    void Update()
    {
        if (CloseWindow)
        {
            window.transform.localRotation = Quaternion.RotateTowards(window.transform.localRotation, targetRot, moveSpeed * Time.deltaTime);

            //start animation
            //start sound effect

            rope.SetActive(false);
            trigger.SetActive(false);
        }
    }
}