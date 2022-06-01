using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public static RuneManager instance;

    public int AmountPressed;

    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (AmountPressed == 5)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        //locks player
        LockPlayer.instance.LockAll();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //play win cutscene

        print("Win");

        //activates win panel
        winPanel.SetActive(true);

        yield return null;
    }

}
