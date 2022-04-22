using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FirstPersonController controller;
    [SerializeField] private MouseLook mouseLook;
    private GameObject pickedUpObject;

    [Header("Settings")]
    [SerializeField] private LayerMask layer;
    [SerializeField] private float rayDistance;
    [SerializeField] private float rotSpeed;

    private bool objectSelected;

    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layer)) //draws a ray going forwards from the object
        {
            //Debug.Log(hit.transform.gameObject.name);

            //enables interact text
            UIManager.instance.isInteracting = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                objectSelected = true;
            }
            else
            {
                controller.UnlockMovement();
                mouseLook.UnlockCamera();
            }
        }
        else
            UIManager.instance.isInteracting = false;

        if (objectSelected)
        {
            //lock player movement and camera
            controller.LockMovement();
            mouseLook.LockCamera();

            //turns interact text off
            UIManager.instance.isInteracting = false;

            //sets reference to object you selected
            pickedUpObject = hit.transform.gameObject;

            //turn input
            float mouseX = (Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime * Mathf.Rad2Deg);
            float mouseY = (Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime * Mathf.Rad2Deg);

            //turns object
            //pickedUpObject.transform.Rotate(Vector3.forward, mouseY);
            //pickedUpObject.transform.Rotate(Vector3.up, mouseX);
            pickedUpObject.transform.Rotate(mouseX, mouseY, 0);

            //unselect object
            if (Input.GetKeyDown(KeyCode.Mouse1))
                objectSelected = false;
        }
    }
    
#if (UNITY_EDITOR)
private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.forward) * rayDistance;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, dir);
    }
#endif
}
