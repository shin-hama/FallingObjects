using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kakera;
using System;

public class ImagePicker : MonoBehaviour
{
    [SerializeField]
    private Unimgpicker imagePicker;

	public Camera mainCamera; //カメラ取得用変数

	[SerializeField]
    private SpriteRenderer imageRenderer;

	public RawImage croppedImageHolder;

	[System.Obsolete]
    void Awake()
    {
        // Unimgpicker returns the image file path.
        imagePicker.Completed += (string path) =>
        {
            StartCoroutine(LoadImage(path, imageRenderer));
        };

        imagePicker.Failed += (string message) =>
        {
            Debug.Log(message);
        };

		mainCamera = Camera.main;
	}

    public void OnPressShowPicker()
    {
        // With v1.1 or greater, you can set the maximum size of the image
        // to save the memory usage.
        imagePicker.Show("Select Image", "unimgpicker.png");
    }

    private IEnumerator LoadImage(string path, SpriteRenderer output)
    {
        yield return new WaitForEndOfFrame(); //フレームの終わりまで待つ（無いと無限ループ）

        //var url = "file://" + path;
        //var www = new WWW(url);
        //yield return www;

        //var texture = www.texture;
        var test = System.IO.File.ReadAllBytes(path);
        var tex= new Texture2D(128, 128);
        var s = tex.LoadImage(test);
        if (s == false)
        {
            Debug.LogError("Failed to load texture url:");
        }

		var point = new Vector3(0.5f, 0.5f, 10);
		var edge = Camera.main.ViewportToWorldPoint(point);

        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f, 0, SpriteMeshType.FullRect);

		GameObject obj = (GameObject)Resources.Load("ImageBox");
		obj.GetComponent<SpriteRenderer>().sprite = sprite;
		Instantiate(obj, edge, Quaternion.identity);
		//output.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 10));
    }

	public void Crop()
	{
		// If image cropper is already open, do nothing
		if (ImageCropper.Instance.IsOpen)
			return;

		StartCoroutine(TakeScreenshotAndCrop());
	}

	private IEnumerator TakeScreenshotAndCrop()
	{
		yield return new WaitForEndOfFrame();

		float minAspectRatio, maxAspectRatio;
		minAspectRatio = 1f;
		maxAspectRatio = 1f;

		Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		screenshot.Apply();

		ImageCropper.Instance.Show(screenshot, (bool result, Texture originalImage, Texture2D croppedImage) =>
		{
			// Destroy previously cropped texture (if any) to free memory
			Destroy(croppedImageHolder.texture, 5f);

			// If screenshot was cropped successfully
			if (result)
			{
				// Assign cropped texture to the RawImage
				croppedImageHolder.enabled = true;
				croppedImageHolder.texture = croppedImage;

				Vector2 size = croppedImageHolder.rectTransform.sizeDelta;
				if (croppedImage.height <= croppedImage.width)
					size = new Vector2(400f, 400f * (croppedImage.height / (float)croppedImage.width));
				else
					size = new Vector2(400f * (croppedImage.width / (float)croppedImage.height), 400f);
				croppedImageHolder.rectTransform.sizeDelta = size;
			}
			else
			{
				croppedImageHolder.enabled = false;
			}

			// Destroy the screenshot as we no longer need it in this case
			Destroy(screenshot);
		},
		settings: new ImageCropper.Settings()
		{
			ovalSelection = true,
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
