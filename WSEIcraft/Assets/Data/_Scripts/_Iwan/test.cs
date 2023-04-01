using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public void loadNext() {
        Debug.Log("next");
        SceneManager.LoadScene("MarioGuide2");
    }
}
