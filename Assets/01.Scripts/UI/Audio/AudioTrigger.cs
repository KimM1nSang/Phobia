using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioObject audioObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Vocals.Instance.Say(audioObject);
    }
}
