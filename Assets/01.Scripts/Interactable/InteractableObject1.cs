using System;
using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject1 : InteractableObject
{


    [ContextMenu("Interaction")]
    public override void Interaction()
    {
        base.Interaction();
        LoadSceneManager.LoadScene(1);
        if (!isInteractable) return;
        IconActive(false);
    }
}
