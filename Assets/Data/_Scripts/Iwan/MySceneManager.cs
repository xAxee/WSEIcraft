using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    
    public void loadScene(string sceneName)
    {
        Debug.Log("Loading scene..." + sceneName);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void newScene(string sceneName)
    {
        Debug.Log("Loading scene..." + sceneName);
        PlayerPrefs.SetString("Save", "");
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
