using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void OnSettingClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }
}
