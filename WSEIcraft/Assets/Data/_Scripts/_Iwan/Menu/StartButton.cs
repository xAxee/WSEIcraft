using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("MarioGuide");
    }

    public void OnButtonCursorEnter() {
    }

    void OnMouseEnter() {
        Debug.Log("tests");
    }
    private void OnMouseOver() {
        Debug.Log("dsfsdf");
    }
}
