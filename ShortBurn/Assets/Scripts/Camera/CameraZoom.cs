using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private GameObject hand;

    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float speed = 1.5f;
    private Vector3 origin;
    private Quaternion rot;

    private bool activateZoom = false;

    public void Start()
    {
        origin = transform.localPosition;
        rot = transform.localRotation;
    }

    private void Update()
    {
        if (activateZoom)
        {
            hand.gameObject.SetActive(false);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);
            transform.localRotation = targetRot;
            //transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRot, speed * Time.deltaTime);

        }
    }

    public void Zoom()
    {
        activateZoom = true;
    }

    public void Reset()
    {
        activateZoom = false;
        hand.gameObject.SetActive(true);


        transform.localPosition = Vector3.Slerp(targetPos, origin, speed);
        transform.localRotation = Quaternion.Slerp(targetRot, rot, speed);
    }
}
