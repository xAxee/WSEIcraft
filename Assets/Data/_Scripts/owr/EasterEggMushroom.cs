using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EasterEggMushroom : ImageFrameActions
{
    [SerializeField] private GameObject light;
    protected override void Interact()
    {
        Destroy(light);
        Destroy(transform.gameObject);
        Debug.Log("interacted: " + gameObject.name);
    }
}
