using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerFov fov;

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
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(fov.GetObjInview().objectName);
                fov.GetObjInview().Interaction();
            }
        }
    }
      


}
