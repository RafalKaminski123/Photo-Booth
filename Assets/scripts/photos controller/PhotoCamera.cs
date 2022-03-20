using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PhotoCamera : MonoBehaviour
{
    private Camera mainCamera;
    Camera photoCam;
    int resWidth = 256;
    int resHeight = 256;

    void Awake()
    {
        photoCam = GetComponent<Camera>();
        mainCamera = Camera.main;
        if (photoCam.targetTexture == null)
        {
            photoCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = photoCam.targetTexture.width;
            resHeight = photoCam.targetTexture.height;
        }
        photoCam.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallTakePhoto();
        }
    }

    public void CallTakePhoto()
    {
        photoCam.orthographicSize = mainCamera.orthographicSize;
        photoCam.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if (photoCam.gameObject.activeInHierarchy)
        {
            Texture2D photoshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            photoCam.Render();
            RenderTexture.active = photoCam.targetTexture;
            photoshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = photoshot.EncodeToPNG();
            string fileName = Output();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log("Photo Taken!");
            photoCam.gameObject.SetActive(false);

        }
    }

    string Output()
    {
        return string.Format("{0}/Output/photo {1}x{2}_{3}.png", Application.dataPath, resWidth, resHeight, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }


}