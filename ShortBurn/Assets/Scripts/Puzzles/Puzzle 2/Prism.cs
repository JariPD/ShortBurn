using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    [SerializeField] private GameObject[] lightBeams;

    public bool ActivateLightBeams;

    void Update()
    {
        if (ActivateLightBeams)
        {
            for (int i = 0; i < lightBeams.Length; i++)
            {
                lightBeams[i].SetActive(true);
            }
        }
        else if (!ActivateLightBeams)
        {
            for (int i = 0; i < lightBeams.Length; i++)
            {
                lightBeams[i].SetActive(false);
            }
        }
    }
}
