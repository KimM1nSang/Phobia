using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventColliderObject : MonoBehaviour
{
    public Action OnEnter;

    public bool isEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isEntered)
        {
            OnEnter?.Invoke();
            isEntered = true;
        }
    }
}
