using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    public static Vocals Instance { get; set; }

    private AudioSource source;

    public Action startOfEnd;
    public Action endOfEnd;

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

    public void ClearActions()
    {
        startOfEnd = null;
        endOfEnd = null;
    }
    public void Processing(AudioObject[] audioObjects)
    {
        StartCoroutine(Process(audioObjects));
    }

    private IEnumerator Process(AudioObject[] clip)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            if (i == clip.Length - 1)
            {
                if (startOfEnd != null)
                    startOfEnd.Invoke();
            }
            PC_UI.Instance.ClearSubtitle();
            yield return new WaitForSeconds(0.2f);
            Say(clip[i]);
            yield return new WaitForSeconds(clip[i].clip != null ? clip[i].clip.length : clip[i].subtitle.Length * 0.4f);
        }
        if (endOfEnd != null)
            endOfEnd.Invoke();
        PC_UI.Instance.ClearSubtitle();
    }
}
