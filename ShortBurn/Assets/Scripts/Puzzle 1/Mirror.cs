using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private float rayDistance = 25f;
    [SerializeField] private LayerMask layer;

    private GameObject rune;

    [SerializeField][Range(0, 5)] private int mirrorIndex;

    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position; 
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        //float thickness = 5f;

        /*if (Physics.SphereCast(origin, thickness, direction, out hit, rayDistance, layer))
        {

        }*/

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer)) //draws a ray going forwards from the object
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Rune"))
            {
                if (mirrorIndex == runeIndex.instance.runeIndexx)
                {
                    Debug.Log(hit.transform.gameObject.name);
                }




                if (hit.transform.gameObject.name == "Rune 1")
                {

                }

                if (hit.transform.gameObject.name == "Rune 2")
                {

                }

                if (hit.transform.gameObject.name == "Rune 3")
                {

                }

                if (hit.transform.gameObject.name == "Rune 4")
                {

                }

                if (hit.transform.gameObject.name == "Rune 5")
                {

                }
            }
        }
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