using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemoveMain : MonoBehaviour
{
    //int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("MiniMap");
    }

}