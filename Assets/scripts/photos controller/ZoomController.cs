using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;


    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    private void Update()
    {
        float ScrollData;
        ScrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= ScrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 1f, 8f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

    }
}
