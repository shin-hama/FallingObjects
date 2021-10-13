using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    private Image Image;
    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MyPointerDownUI()
    {
        Settings.image = Image.sprite;
    }

}
