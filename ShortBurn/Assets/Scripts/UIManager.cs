using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool isInteracting = false;
    [SerializeField] private TextMeshProUGUI moveToCenterText;
    private Canvas interactCanvas;


    private void Awake()
    {
        instance = this;

        interactCanvas = GetComponentInChildren<Canvas>();
    }

    void Update()
    {
        if (isInteracting)
            interactCanvas.enabled = true;
        else
            interactCanvas.enabled = false;

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
