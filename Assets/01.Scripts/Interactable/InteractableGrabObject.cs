using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGrabObject : InteractableObject
{
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public override void Interaction()
    {
        base.Interaction();
        PlayerInventory.instance.grabedObject = this;
        gameObject.transform.parent = PlayerInventory.instance.grabObjectHandTransform;
        //GravityActive(false);
    }
    public void ObjectDrop()
    {
        gameObject.transform.parent = null;
        gameObject.transform.localScale = Vector3.one;
        //GravityActive(true);
    }
    public void GravityActive(bool active)
    {
        rigid.isKinematic = !active;
        //rigid.useGravity = active;
    }
}
