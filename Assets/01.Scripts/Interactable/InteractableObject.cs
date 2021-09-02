using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName;

    /// <summary>
    /// Switchable : �ȵ� �� �� �ִ��� || Lookable : ���� �� �� �ִ���
    /// </summary>
    private enum InteractState
    {
        Switchable,
        Lookable
    }
    /// <summary>
    /// �κ��丮�� �������ִ���
    /// </summary>
    private bool isPickable;

    private InteractState interactState = InteractState.Lookable;

    [ContextMenu("Interaction")]
    public void Interaction()
    {
        Debug.Log("Perform operation");
    }

    public void ReadyToInteraction()
    {
        Debug.Log("ReadyToInteract!");
    }

}
