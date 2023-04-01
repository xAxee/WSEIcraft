using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario_continue : MonoBehaviour
{
    public void nextScene(string name)
    {
        Debug.Log("next scene " + name);
        SceneManager.LoadScene(name);
    }
}
