using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PhotoCameraOne : MonoBehaviour
{
    Camera photoCam;
    int resWidth = 256;
    int resHeight = 256;

     void Awake()
     {
        photoCam = GetComponent<Camera>();
        if(photoCam.targetTexture == null)
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
    public void CallTakePhoto()
    {
        photoCam.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if(photoCam.gameObject.activeInHierarchy)
        {
            Texture2D photoshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            photoCam.Render();
            RenderTexture.active = photoCam.targetTexture;
            photoshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = photoshot.EncodeToPNG();
            string fileName = PhotoName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log("Photo Taken!");
            photoCam.gameObject.SetActive(false);

        }
    }

    string PhotoName()
    {
        return string.Format("{0}/PhotoShots/photo {1}x{2}_{3}.png", Application.dataPath, resWidth, resHeight, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
        

}
