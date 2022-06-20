using UnityEngine;

public class WindowPuzzle : MonoBehaviour
{
    public bool CloseWindow;

    [Header("References")]
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject trigger;
    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (CloseWindow)
        {
            anim.SetTrigger("CloseWindow");

            //start animation
            //start sound effect

            rope.SetActive(false);
            trigger.SetActive(false);
        }
    }
}