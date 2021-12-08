using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEmergencyLight : MonoBehaviour
{
    [SerializeField] private float blinkTime = 1;
    private float currentTime = 0;
    [SerializeField] private GameObject blinkObj = null;

    private void Update()
    {
        if (currentTime >= blinkTime)
        {
            blinkObj.SetActive(!blinkObj.activeSelf);
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

    }
}
