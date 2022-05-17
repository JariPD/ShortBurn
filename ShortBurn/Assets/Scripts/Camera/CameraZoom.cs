using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float speed;
    private Vector3 origin;
    private Quaternion rot;

    public void Start()
    {
        origin = transform.localPosition;
        rot = transform.localRotation;
    }

    public void Zoom()
    {
        transform.localPosition = Vector3.Slerp(origin, targetPos, speed);
        transform.localRotation = Quaternion.Slerp(rot, targetRot, speed);
    }

    public void Reset()
    {
        transform.localPosition = Vector3.Slerp(targetPos, origin, speed);
        transform.localRotation = Quaternion.Slerp(targetRot, rot, speed);
    }
}
