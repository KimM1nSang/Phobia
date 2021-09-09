using System;
using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName;
    [SerializeField]
    private Transform intercatIconPos;
    [SerializeField]
    private GameObject intercatIcon;

    public bool interactable { get; set; } = true;

    public bool pickable { get; set; } = true;

    private void Awake()
    {
        intercatIcon.transform.position = intercatIconPos.position;
        IconActive(false);
    }

    [ContextMenu("Interaction")]
    public virtual void Interaction()
    {
        if(interactable)
        {
            if (pickable)
            {
                Pick();
            }
            else
            {
                Switch();
            }
        }
    }

    public virtual void Pick()
    {
        Debug.Log("Pick");
    }

    public virtual void Switch()
    {
        Debug.Log("Switch");

    }
    public virtual void ReadyToInteraction()
    {
        Debug.Log("ReadyToInteract!");
    }

    public void IconActive(bool isActive)
    {
        intercatIcon.SetActive(isActive);
    }

}
