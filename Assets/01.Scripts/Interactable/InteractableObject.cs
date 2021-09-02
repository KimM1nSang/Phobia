using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectName;

    /// <summary>
    /// Switchable : 똑딱 할 수 있는지 || Lookable : 구경 할 수 있는지
    /// </summary>
    private enum InteractState
    {
        Switchable,
        Lookable
    }

    /// <summary>
    /// 인벤토리에 넣을수있는지
    /// </summary>
    private bool isPickable;

    private InteractState interactState = InteractState.Lookable;

    [ContextMenu("Interaction")]
    public virtual void Interaction()
    {
        Debug.Log("Perform operation");
    }

    public virtual void ReadyToInteraction()
    {
        Debug.Log("ReadyToInteract!");
    }

}
