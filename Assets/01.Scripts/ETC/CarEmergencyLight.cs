using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEmergencyLight : MonoBehaviour
{
    [SerializeField] private float blinkTime = 1;
    [SerializeField] private GameObject blinkObj = null;
    void Start()
    {
        StartCoroutine(LightBlink());
    }

    private IEnumerator LightBlink()
    {
        yield return new WaitForSeconds(blinkTime);
        blinkObj.SetActive(!blinkObj.activeSelf);
        StartCoroutine(LightBlink());
    }
}
