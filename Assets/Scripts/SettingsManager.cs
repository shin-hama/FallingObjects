using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject Item;
    public static bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        Item.GetComponent<Image>().sprite = Settings.image;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            Item.GetComponent<Image>().sprite = Settings.image;
            isClicked = false;
        }
    }

    public void OnOKClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}