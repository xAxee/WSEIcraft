using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QueenDied : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] CinemachineVirtualCamera endCamera;
    [SerializeField] TextMeshProUGUI endScreen;
    public GameObject endScreenGO;
    private bool levelEnd = false;
    private void Start()
    {
        audio.mute = true;
        bgMusic.mute = false;
        bgMusic.loop = true;
        endScreenGO.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio.mute = false;
            bgMusic.mute = true;
            audio.Play();
            Destroy(this.gameObject);
            endCamera.Priority = 11;
            levelEnd = true;;
            endScreenGO.SetActive(true);
        }
    }
    
}
