using System;
using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName;
    [SerializeField]
    protected Transform intercatIconPos;
    [SerializeField]
    protected GameObject intercatIcon;

    public bool isInteractable { get; set; } = false;

    protected virtual void Awake()
    {
        intercatIcon.transform.position = intercatIconPos.position;
        IconActive(false);
    }

    [ContextMenu("Interaction")]
    public virtual void Interaction()
    {
        if (!isInteractable) return;
        IconActive(false);
    }

    public void IconActive(bool isActive)
    {
        intercatIcon.SetActive(isActive);
    }
	protected virtual void Update()
	{
        if (!isInteractable) return;
	}
}
