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

    /// <summary>
    /// 오디오 소스 실행 및 자막 실행
    /// </summary>
    /// <param name="clip">오디오 오브젝트</param>
    public void Say(AudioObject clip)
    {
        if (source.isPlaying)
            source.Stop();

        source.PlayOneShot(clip.clip);

        PC_UI.Instance.SetSubtitle(clip.subtitle, clip.clip != null ? clip.clip.length : 6);
    }
}
