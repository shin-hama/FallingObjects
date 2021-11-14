using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kakera;
using System;

public class ImagePicker : MonoBehaviour
{
    [SerializeField]
    public Unimgpicker imagePicker;

    [System.Obsolete]
    void Awake()
    {
        // Unimgpicker returns the image file path.
        imagePicker.Completed += (string path) =>
        {
            StartCoroutine(LoadImage(path));
            UnityEngine.SceneManagement.SceneManager.LoadScene("CropImage");
        };

        imagePicker.Failed += (string message) =>
        {
            Debug.Log(message);
        };
    }

    public void OnPressShowPicker()
    {
        // With v1.1 or greater, you can set the maximum size of the image
        // to save the memory usage.
        imagePicker.Show("Select Image", "unimgpicker.png");
    }

    private IEnumerator LoadImage(string path)
    {
        yield return new WaitForEndOfFrame(); //�t���[���̏I���܂ő҂i�����Ɩ������[�v�j

        var test = System.IO.File.ReadAllBytes(path);
        var tex = new Texture2D(128, 128);
        var s = tex.LoadImage(test);
        if (s == false)
        {
            Debug.LogError("Failed to load texture url:");
        }

        var point = new Vector3(0.5f, 0.5f, 10);
        var edge = Camera.main.ViewportToWorldPoint(point);

        CropImageMaster.LoadedImage = tex;
    }

}
