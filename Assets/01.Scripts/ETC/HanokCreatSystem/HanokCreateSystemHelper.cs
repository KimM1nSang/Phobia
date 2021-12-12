using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanokCreateSystemHelper : MonoBehaviour
{
    public bool isPlayerStay = false;
    public int hanokIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Is In");
            isPlayerStay = true;
            HanokCreateSystem.Instance.OnPlayerChangeHanokIdx?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Is Out");
            isPlayerStay = false;
        }
    }
}
