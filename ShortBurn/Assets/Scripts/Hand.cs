using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10;
    [SerializeField] private LayerMask layerToHit;
    [SerializeField] private CameraShake cameraShake;

    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //play screenshake effect
            StartCoroutine(cameraShake.Shake(0.15f, .05f));

            if (Physics.Raycast(origin, direction, out hit, rayDistance, layerToHit)) //draws a ray going forwards from the object
            {
                //play beam vfx
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

