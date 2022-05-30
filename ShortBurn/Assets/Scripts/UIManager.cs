using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool isInteracting = false;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI moveToCenterText;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isInteracting)
            interactText.gameObject.SetActive(true);
        else
            interactText.gameObject.SetActive(false);

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
