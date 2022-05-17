using UnityEngine;

public class Sway : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerInteraction playerInteraction;

    [Header("Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;

    void Update()
    {
        //input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        //calculate rotations
        Quaternion rotX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRot = rotX * rotY;

        //rotate
        if (!playerInteraction.MirrorSelected && !playerInteraction.ZoomSelected)
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, smooth * Time.deltaTime);

    }
}
