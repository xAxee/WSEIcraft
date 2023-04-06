using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteUsage : ImageFrameActions
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject noteUI;
    [SerializeField] private Image noteUIGameImage;
    [SerializeField] private Sprite spriteImage;
    [SerializeField] private TextMeshProUGUI noteTextUI;
    protected override void Interact()
    {
        noteUI.transform.localScale = new Vector3(3f, 4f, 0f);
        noteUIGameImage.transform.localScale = new Vector3(2.75f, 3.5f, 0f);
        noteUIGameImage.sprite = spriteImage;
        noteTextUI.SetText("Press [SPACE] to continue");
        Destroy(light);
        Destroy(transform.gameObject);
        Debug.Log("interacted: " + gameObject.name);
    }

    protected override void HideInteraction()
    {
        noteUI.transform.localScale = new Vector3(0f, 4f, 0f);
        noteUIGameImage.transform.localScale = new Vector3(0f, 3.5f, 0f);
        noteTextUI.SetText(string.Empty);
    }


}
