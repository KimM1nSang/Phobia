using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableConditionDragObject : InteractableDragObject
{
    [SerializeField] private string necObjectId = "";
    public override void Interaction()
    {
        if (PlayerInventory.instance.grabedObject == null || PlayerInventory.instance.grabedObject.objectName != necObjectId) return;
        base.Interaction();
        Debug.Log("AAAAAAAAAAAA");
    }
}
