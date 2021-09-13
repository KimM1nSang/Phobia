using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public Transform grabObjectForwardTransform;
    public Transform grabObjectHandTransform;

    public InteractableObject grabedObject;
    private enum GrabObjectState
    {
        OnHand,
        OnForward
    }
    private GrabObjectState grabState = GrabObjectState.OnForward;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("이미 인벤토리가 존재합니다.");
        }
        instance = this;
    }

    void Update()
    {
        if(grabedObject != null)
        {
            InteractableGrabObject grabObj = grabedObject.GetComponent<InteractableGrabObject>();
            if (PlayerInput.instance.interact)
            {
                grabedObject.transform.parent = grabObjectHandTransform;
                grabObj.GravityActive(false);
                if (grabState == GrabObjectState.OnHand)
                {
                    grabState = GrabObjectState.OnForward;

                    grabedObject.transform.position = grabObjectForwardTransform.position;

                    GameManager.instance.canMove = GameManager.instance.canLook = false;
                }
                else
                {
                    grabState = GrabObjectState.OnHand;
                    
                    grabedObject.transform.position = grabObjectHandTransform.position;
                    
                    GameManager.instance.canMove = GameManager.instance.canLook = true;
                }
            }
            if(PlayerInput.instance.objectDrop)
            {
                grabObj.GravityActive(true);
                grabState = GrabObjectState.OnForward;
                GameManager.instance.canMove = GameManager.instance.canLook = true;
                grabedObject.GetComponent<InteractableGrabObject>().ObjectDrop();
                grabedObject = null;
            }
        }


    }
}
