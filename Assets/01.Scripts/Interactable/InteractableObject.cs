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

    private void Awake()
    {
        intercatIcon.transform.position = intercatIconPos.position;
        IconActive(false);
    }

    [ContextMenu("Interaction")]
    public virtual void Interaction()
    {
        if (!interactable) return;
        Debug.Log("Interact");
    }

    public void IconActive(bool isActive)
    {
        intercatIcon.SetActive(isActive);
    }
}
