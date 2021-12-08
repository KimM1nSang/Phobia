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
    /// ����� �ҽ� ���� �� �ڸ� ����
    /// </summary>
    /// <param name="clip">����� ������Ʈ</param>
    public void Say(AudioObject clip)
    {
        if (source.isPlaying)
            source.Stop();


        if (clip.clip != null)
            source.PlayOneShot(clip.clip);

        PC_UI.Instance.SetSubtitle(clip.subtitle, clip.clip != null ? clip.clip.length : PC_UI.Instance.SubstringColorCommand(clip.subtitle).Length* 0.4f);
    }
}
