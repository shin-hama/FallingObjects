using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropImageMaster : MonoBehaviour
{
    public static Texture2D LoadedImage = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadedImage)
        {
            Crop();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
        }
    }

    public void Crop()
    {
        // If image cropper is already open, do nothing
        if (ImageCropper.Instance.IsOpen)
            return;

        StartCoroutine(TakeScreenshotAndCrop(LoadedImage));
    }

    private IEnumerator TakeScreenshotAndCrop(Texture2D image)
    {
        yield return new WaitForEndOfFrame();

        float minAspectRatio, maxAspectRatio;
        minAspectRatio = 1f;
        maxAspectRatio = 1f;

        ImageCropper.Instance.Show(image, (bool result, Texture originalImage, Texture2D croppedImage) =>
        {
            if (result)
            {
                SettingsManager.croppedTexture = croppedImage;
            }

            // Destroy the screenshot as we no longer need it in this case
            Destroy(image);
            LoadedImage = null;
        },
        settings: new ImageCropper.Settings()
        {
            ovalSelection = false,
            autoZoomEnabled = true,
            imageBackground = Color.clear, // transparent background
            selectionMinAspectRatio = minAspectRatio,
            selectionMaxAspectRatio = maxAspectRatio

        },
        croppedImageResizePolicy: (ref int width, ref int height) =>
        {
            // uncomment lines below to save cropped image at half resolution
            //width /= 2;
            //height /= 2;
        });
    }

}
