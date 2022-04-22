using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private float rayDistance = 25f;
    [SerializeField] private LayerMask layer;

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
            print("Hit something");
            Debug.Log(hit.transform.gameObject.name);  //debugs the name of the object you hit
            //do check if light hit rune
            //emission of rune ^
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