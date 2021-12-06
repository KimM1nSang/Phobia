using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropPoint : MonoBehaviour
{
    [SerializeField]
    private bool isUnactiveAtStart = false;
    private void Start()
    {
        gameObject.SetActive(!isUnactiveAtStart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("interactable"))
        {
            if(other.GetComponent<InteractableGrabObject>() != null&& PlayerInventory.instance.grabedObject == null)
            {
                Debug.Log("DROP!");
                Destroy(gameObject);
            }

        }
    }
}
