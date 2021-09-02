using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerFov fov;
    public PlayerInput input;
    private void Start()
    {
        fov = GetComponent<PlayerFov>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fov.IsObjInFov() && fov.IsViewObj())
        {
            fov.GetObjInview().ReadyToInteraction();
            if (input.interact)
            {
                Debug.Log(fov.GetObjInview().objectName);
                fov.GetObjInview().Interaction();
            }
        }
    }
      


}
