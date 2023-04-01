using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueenDied : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera endCamera;
    [SerializeField] TextMeshProUGUI endScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endScreen.text = "WSEICRAFT";
            endCamera.Priority = 11;
            Destroy(this.gameObject);
        }
    }
}
