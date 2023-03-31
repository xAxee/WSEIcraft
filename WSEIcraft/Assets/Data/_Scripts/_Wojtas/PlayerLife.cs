using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    PlayerScript player;
    private void Start()
    {
        player = GetComponent<PlayerScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            Debug.Log("died");
            player.playerDied();
        }
    }
}
