using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ImageFrameActions : MonoBehaviour
{
    public string noteMessage;
    public string noteSceneName;
    public void BaseInteract()
    {
        Interact();
    }

    public void HideInteract()
    {
        HideInteraction();
    }
    protected virtual void Interact()
    {
        
    }

    protected virtual void HideInteraction()
    {
        
    }
}