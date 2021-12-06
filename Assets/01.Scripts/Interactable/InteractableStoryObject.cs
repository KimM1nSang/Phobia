using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableStoryObject : InteractableObject
{
    public override void Interaction()
    {
        base.Interaction();
        GetComponent<SubtitleProcess>().Processing();
    }
}
