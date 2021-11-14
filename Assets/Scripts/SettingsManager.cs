using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public RawImage croppedImageHolder;
    public static Texture2D croppedTexture;

    // Start is called before the first frame update
    void Start()
    {
        if (croppedTexture)
        {
            initCroppedImage();
        }
    }

    private void initCroppedImage()
    {
        // Destroy previously cropped texture (if any) to free memory
        Destroy(croppedImageHolder.texture, 5f);

        // If screenshot was cropped successfully
        // Assign cropped texture to the RawImage
        croppedImageHolder.enabled = true;
        croppedImageHolder.texture = croppedTexture;

        var length = croppedImageHolder.rectTransform.sizeDelta.x;

        Vector2 size = croppedImageHolder.rectTransform.sizeDelta;
        if (croppedTexture.height <= croppedTexture.width)
            size = new Vector2(length, length * (croppedTexture.height / (float)croppedTexture.width));
        else
            size = new Vector2(length * (croppedTexture.width / (float)croppedTexture.height), length);
        croppedImageHolder.rectTransform.sizeDelta = size;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnOKClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
