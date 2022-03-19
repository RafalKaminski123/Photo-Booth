using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PhotoCameraOne photoCam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photoCam.CallTakePhoto();
        }
    }
}
