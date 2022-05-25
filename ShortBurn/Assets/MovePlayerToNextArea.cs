using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToNextArea : MonoBehaviour
{
    public static MovePlayerToNextArea instance;

    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float moveSpeed;

    public bool MoveObject;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (MoveObject)
        {
            var test = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            transform.position = test;
        }
            
    }
}
