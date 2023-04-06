using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tetrBlockKill : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOver();
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene("Tetris", LoadSceneMode.Single);
    }
}
