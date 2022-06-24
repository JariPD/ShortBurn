using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    public float Delay = 0.1f;
    public string Fulltext;
    private string currentText = "";

    void Start()
    {

    }
    IEnumerator ShowText()
    {
        for (int i = 0; i < Fulltext.Length; i++)
        {
            currentText = Fulltext.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(Delay);
        }
    }
}
