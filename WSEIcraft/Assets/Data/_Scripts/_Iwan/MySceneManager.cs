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
}
