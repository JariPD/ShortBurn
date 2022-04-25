using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Header("Ray Settings")]
    [SerializeField] private float rayDistance = 25f;
    [SerializeField] private LayerMask layerToHit;
    private RaycastHit hit;

    [Header("Mirror Settings")]
    [SerializeField] private int mirrorIndex;

    [Header("Rune Settings")]
    private GameObject rune;

    private bool coroutineAllowed = true;

    void Update()
    {
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layerToHit)) //draws a ray going forwards from the object
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Rune")) //checks if the object is in the correct layer
            {
                for (int i = 1; i <= 5; i++)
                {
                    //checks if index is the same as the object that is hit if so start GetRune coroutine
                    if (mirrorIndex == i && hit.transform.gameObject.name == $"Rune {i}" && coroutineAllowed)
                        StartCoroutine(GetRune());
                }
            }
        }
    }

    /// <summary>
    /// Coroutine to get rune object and put it in a empty gameobject and changes the color of the object that is hit
    /// </summary>
    /// <returns></returns>
    IEnumerator GetRune()
    {
        //bool to make sure coroutine is not started multiple times
        coroutineAllowed = false;
        
        //puts the hit object into an empty GameObject
        rune = hit.transform.gameObject;

        //changes the material of the object
        rune.GetComponent<Renderer>().material.color = new Color(127, 0, 255);

        //increases the amount of active runes
        PuzzleManager.instance.AmountActive++;

        yield return null;
    }


    /// <summary>
    /// Editor only, Gizmos for raycast
    /// </summary>
#if (UNITY_EDITOR) 
    private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.forward) * rayDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, dir);
    }
#endif
}