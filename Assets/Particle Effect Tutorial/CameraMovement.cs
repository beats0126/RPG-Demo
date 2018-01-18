using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;

    public float speed;

    public Vector3 offset;
    public float zoomSpeed = 5.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 15.0f;

    public float pitch = 2.0f;

    private float currentZoom = 14.0f;

    private float yawSpeed = 100.0f;
    private float currentYaw = 0.0f;

    // Use this for initialization
    void Start () {

    }
	
	void Update()
    {
        currentZoom -= Input.GetAxis("Vertical") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
