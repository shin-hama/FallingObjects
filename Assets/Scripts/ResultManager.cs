using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    public Text resultMessageText;

    // Use this for initialization
    void Start()
    {
        resultMessageText.text = ResultContainer.ResultMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetryClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void OnHomeClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
