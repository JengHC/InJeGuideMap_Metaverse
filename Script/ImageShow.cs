using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageShow : MonoBehaviour
{

    public bool isImgOn;
    public Image img;

    void Start()
    {
        img.enabled = false;
        isImgOn = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            img.enabled = !img.enabled;
        }
    }
}
