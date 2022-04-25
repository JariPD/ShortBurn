using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10;
    [SerializeField] private LayerMask layer;

    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(origin, direction, out hit, rayDistance, layer)) //draws a ray going forwards from the object
            {

            }
        }

        
    }

#if (UNITY_EDITOR)
    private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.up) * rayDistance;

        Gizmos.color = Color.cyan;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Gizmos.DrawRay(transform.position, dir);
        }
    }
#endif
}

