using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;
    [SerializeField] private float time;
    private Vector3 origin;

    public void Start()
    {
        origin = transform.localPosition;
    }

    public void Zoom()
    {
        transform.localPosition = Vector3.Slerp(origin, targetPos, time);
        transform.localRotation = targetRot;
    }
}
