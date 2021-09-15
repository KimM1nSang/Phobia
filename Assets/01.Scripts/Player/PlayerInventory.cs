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
            if(grabState == GrabObjectState.OnForward)
            {
                grabedObject.transform.RotateAround(Vector3.up, -PlayerInput.instance.mouseX * Mathf.Deg2Rad);
                grabedObject.transform.RotateAround(grabObjectForwardTransform.right, PlayerInput.instance.mouseY * Mathf.Deg2Rad);
                //grabedObject.transform.rotation = Quaternion.Euler(grabedObject.transform.rotation.eulerAngles.y + PlayerInput.instance.mouseY, grabedObject.transform.rotation.eulerAngles.y + PlayerInput.instance.mouseY,0);
            }
            InteractableGrabObject grabObj = grabedObject.GetComponent<InteractableGrabObject>();
            if (PlayerInput.instance.interact)
            {
                grabedObject.transform.parent = grabObjectHandTransform;

                grabObj.GravityActive(false);

                switch (grabState)
                {
                    case GrabObjectState.OnHand:

                        grabState = GrabObjectState.OnForward;

                        grabedObject.transform.rotation = grabedObject.transform.parent.rotation;
                        grabedObject.transform.LookAt(transform.position);
                        grabedObject.transform.position = grabObjectForwardTransform.position;

                        GameManager.instance.canMove = false;
                        GameManager.instance.canLook = false;
                        break;
                    case GrabObjectState.OnForward:

                        grabState = GrabObjectState.OnHand;

                        grabedObject.transform.rotation = grabedObject.transform.parent.rotation;
                        grabedObject.transform.LookAt(transform.position);

                        grabedObject.transform.position = grabObjectHandTransform.position;

                        GameManager.instance.canMove = true;
                        GameManager.instance.canLook = true;
                        break;
                    default:
                        break;
                }
            }
            if(PlayerInput.instance.objectDrop)
            {
                grabObj.GravityActive(true);
                grabState = GrabObjectState.OnForward;
                GameManager.instance.canMove = true;
                GameManager.instance.canLook = true;
                grabedObject.GetComponent<InteractableGrabObject>().ObjectDrop();
                grabedObject = null;
            }
        }


    }
}
