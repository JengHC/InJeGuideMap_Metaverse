using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemoveNeul : MonoBehaviour
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
        SceneManager.LoadScene("Neul Inside");
    }

}