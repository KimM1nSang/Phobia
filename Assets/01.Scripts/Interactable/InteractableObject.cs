using System;
using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public AudioObject audioObject;
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
        if (audioObject != null)
            Vocals.Instance.Say(audioObject);
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
