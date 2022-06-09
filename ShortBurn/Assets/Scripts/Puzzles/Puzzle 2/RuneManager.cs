using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public static RuneManager instance;

    public int AmountActive;

    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (AmountActive == 5)
            {
                StartCoroutine(Win());
            }
        }
    }

    IEnumerator Win()
    {
        //locks player
        LockPlayer.instance.LockAll();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //play win cutscene

        //activates win panel
        winPanel.SetActive(true);

        yield return null;
    }

}
