using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerFov fov;
    private PlayerInput input;

    private InteractableObject interactingObj;
    private void Start()
    {
        fov = GetComponent<PlayerFov>();
        input = PlayerInput.instance;
    }
    // Update is called once per frame
    void Update()
    {   
        if (fov.IsObjInAround())
        {
			foreach (var item in fov.GetObjInAround())
			{
                item.GetComponent<InteractableObject>().isInteractable = true;
			}
        }
        if (fov.IsObjInFov())
        {
            interactingObj = fov.GetObjInview();
            if (fov.IsViewObj())
            {
                interactingObj.IconActive(true);
                if (input.interact)
                {
                    Debug.Log(interactingObj.objectName);
                    interactingObj.Interaction();
                    
                }
            }
            else
            {
                foreach (var item in fov.GetObjInFov())
                {
                    item.GetComponent<InteractableObject>().IconActive(false);
                }
            }

        }
    }

}
