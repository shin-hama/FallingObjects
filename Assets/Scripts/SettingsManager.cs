using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Settings.image != null)
        {
            Item.GetComponent<Image>().sprite = Settings.image;
        }
    }

    public void OnOKClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}