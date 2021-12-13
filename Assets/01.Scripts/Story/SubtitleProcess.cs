using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleProcess : MonoBehaviour
{

    [SerializeField]
    protected AudioObject[] audioObjects;

    public virtual void Processing()
    {
        StartCoroutine(Process(audioObjects));
    }
	protected virtual IEnumerator Process(AudioObject[] clip)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            if (i == clip.Length - 1)
            {
                StartOfEndProcess();
            }
            PC_UI.Instance.ClearSubtitle();
            yield return new WaitForSeconds(0.2f);
            Vocals.Instance.Say(clip[i]);
            yield return new WaitForSeconds(clip[i].clip != null ? clip[i].clip.length : clip[i].subtitle.Length * 0.4f);
        }
        EndOfEndProcess();
        PC_UI.Instance.ClearSubtitle();
    }
    protected virtual void StartOfEndProcess()
    {

    }
    protected virtual void EndOfEndProcess()
    {

    }
}
