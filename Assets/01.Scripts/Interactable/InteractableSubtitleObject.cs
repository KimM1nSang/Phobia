using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSubtitleObject : InteractableObject
{
    public AudioObject audioObject;
    public override void Interaction()
    {
        base.Interaction();
        if (audioObject != null)
            Vocals.Instance.Say(audioObject);
    }
}
