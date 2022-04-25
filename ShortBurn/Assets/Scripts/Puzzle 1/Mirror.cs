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

    private bool allowedToRunCourotine = true;

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
                    if (mirrorIndex == i && hit.transform.gameObject.name == $"Rune {i}" && allowedToRunCourotine)
                        StartCoroutine(GetRune());
                }
            }
        }
    }

    IEnumerator GetRune()
    {
        allowedToRunCourotine = false;
         
        rune = hit.transform.gameObject;
        rune.GetComponent<Renderer>().material.color = new Color(127, 0, 255);

        PuzzleManager.instance.AmountActive++;

        Debug.Log(hit.transform.gameObject.name);

        yield return null;
    }


#if (UNITY_EDITOR) 
    private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.forward) * rayDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, dir);
    }
#endif
}