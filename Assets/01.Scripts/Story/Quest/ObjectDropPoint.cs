using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropPoint : MonoBehaviour
{
    [SerializeField]
    private bool isUnactiveAtStart = false;

    [SerializeField]
    private string questName = "";
    protected virtual void Start()
    {
        gameObject.SetActive(!isUnactiveAtStart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("interactable"))
        {
            if(other.GetComponent<InteractableGrabObject>() != null&& PlayerInventory.instance.grabedObject == null)
            {
                OnDropObject();
            }
        }
    }
    public virtual void OnDropObject()
    {
        Debug.Log("DROP!");
        PC_UI.Instance.PopUpQuestBox(true);
        PC_UI.Instance.UpProgress(questName);
    }
}
