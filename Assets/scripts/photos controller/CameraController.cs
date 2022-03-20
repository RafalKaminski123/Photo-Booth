using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PhotoCamera photoCam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photoCam.CallTakePhoto();
        }
    }
    

    public void TakePhoto()
    {
        photoCam.CallTakePhoto();
    }




}
