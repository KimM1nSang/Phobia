using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    public static Vocals Instance { get; set; }

    private AudioSource source;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioObject clip)
    {
        if (source.isPlaying)
            return;
            //source.Stop();

        source.PlayOneShot(clip.clip);

        PC_UI.Instance.SetSubtitle(clip.subtitle, clip.clip.length);
    }
}
