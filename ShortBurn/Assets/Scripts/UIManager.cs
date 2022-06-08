using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool IsInteracting = false;
    public bool IsPaused;
    public bool ObjectSelected;

    [SerializeField] private TextMeshProUGUI moveToCenterText;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Canvas interactCanvas;
    [SerializeField] private Canvas objectSelectedCanvas;

    private void Awake()
    {
        instance = this;

        //locks cursor and makes it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //if player is ineracting turns interacting text on or off
        if (IsInteracting)
            interactCanvas.enabled = true;
        else
            interactCanvas.enabled = false;

        //if object is selected turn on text that tells player how to deselect
        if (ObjectSelected)
            objectSelectedCanvas.enabled = true;
        else
            objectSelectedCanvas.enabled = false;

        //pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;

            if (IsPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                LockPlayer.instance.LockAll();
                pauseMenu.SetActive(true);

            }
            if (!IsPaused)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                LockPlayer.instance.UnlockAll();
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Puzzle1Win()
    {
        StartCoroutine(MoveToCenter());
    }

    IEnumerator MoveToCenter()
    {
        moveToCenterText.enabled = true;

        yield return new WaitForSeconds(4.5f);

        moveToCenterText.enabled = false;
    }

    

}
