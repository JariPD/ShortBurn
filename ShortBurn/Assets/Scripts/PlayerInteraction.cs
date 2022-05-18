using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private FirstPersonController controller;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private CameraZoom cameraZoom;
    private GameObject mirrorObject;
    private GameObject runeObject;

    [Header("Settings")]
    [SerializeField] private LayerMask layerToHit;
    [SerializeField] private float rayDistance;
    [SerializeField] private float rotSpeed;

    public bool MirrorSelected;
    public bool ZoomSelected;
    public bool RunePressed;

    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layerToHit)) //draws a ray going forwards from the object
        {
            //Debug.Log(hit.transform.gameObject.name);

            //enables interact text
            if (hit.transform.gameObject.CompareTag("Untagged"))
                return;

            UIManager.instance.isInteracting = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.gameObject.CompareTag("Mirror"))
                    MirrorSelected = true;

                if (hit.transform.gameObject.CompareTag("Zoom"))
                    ZoomSelected = true;

                if (hit.transform.gameObject.CompareTag("Rune"))
                    RunePressed = true;
            }
            else
            {
                controller.UnlockMovement();
                mouseLook.UnlockCamera();
            }
        }
        else
            UIManager.instance.isInteracting = false;

        if (MirrorSelected)
        {
            //lock player movement and camera
            controller.LockMovement();
            mouseLook.LockCamera();

            //turns interact text off
            UIManager.instance.isInteracting = false;

            //sets reference to object you selected
            mirrorObject = hit.transform.gameObject;

            //turn input
            float mouseX = (Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime * Mathf.Rad2Deg);
            float mouseY = (Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime * Mathf.Rad2Deg);

            //turns object
            mirrorObject.transform.Rotate(Vector3.right, mouseY);
            mirrorObject.transform.Rotate(Vector3.up, mouseX);

            //unselect object
            if (Input.GetKeyDown(KeyCode.Mouse1))
                MirrorSelected = false;
        }

        if (ZoomSelected)
        {
            //lock player movement and camera
            controller.LockMovement();
            mouseLook.LockCamera();

            //zooms the camera to another position
            cameraZoom.Zoom();

            //unselect object
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ZoomSelected = false;
                cameraZoom.Reset();
            }
        }

        if (RunePressed)
        {
            //sets reference to object you pressed
            runeObject = hit.transform.gameObject;

            Rune();
        }
    }

    private void Rune()
    {
        //increases the rune count
        RuneManager.instance.AmountPressed++;

        //removes tag from object so it cant be pressed again
        runeObject.tag = "Untagged";

        //change runes appearance to indicate it being pressed
        runeObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);

        //turns the ineracting text off
        UIManager.instance.isInteracting = false;

        RunePressed = false;
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
