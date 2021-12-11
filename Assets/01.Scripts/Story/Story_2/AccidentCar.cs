using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentCar : MonoBehaviour
{
    [SerializeField] private float CarSpeed = 1;
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * CarSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LoadSceneManager.LoadScene("Room_white");
        }
    }
}
