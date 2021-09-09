using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerFov fov;
    public PlayerInput input;

    private InteractableObject interactingObj;
    private void Start()
    {
        fov = GetComponent<PlayerFov>();
    }
    // Update is called once per frame
    void Update()
    {
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
