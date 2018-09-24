using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public Transform target;
    public float smoothTime = 0.2f;
    public float posY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3 (Mathf.Clamp (desiredPosition.x,minX,maxX),
            Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z);
    }

}
