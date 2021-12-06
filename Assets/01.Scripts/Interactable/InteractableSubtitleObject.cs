using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSubtitleObject : InteractableObject
{
    public AudioObject audioObject;
    public override void Interaction()
    {
        base.Interaction();
        if(GetComponent<StoryProcess_2>() != null)
        {
            GetComponent<StoryProcess_2>().StoryProcessing();
        }
        else
        {
            if (audioObject != null)
                Vocals.Instance.Say(audioObject);
        }
    }
}
