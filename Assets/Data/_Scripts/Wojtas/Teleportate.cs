using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportate : MonoBehaviour
{
    [SerializeField] Transform secondTube;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(secondTube.transform.position.x, secondTube.transform.position.y+1,secondTube.transform.position.z);
        }
    }
}
