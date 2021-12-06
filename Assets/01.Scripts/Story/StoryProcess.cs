using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProcess : MonoBehaviour
{

    [SerializeField]
    protected AudioObject[] audioObjects;

    public virtual void StoryProcessing()
    {
        PC_UI.Instance.PopUpQuestBox(true);
        StartCoroutine(Process(audioObjects));
    }
    
    protected virtual IEnumerator Process(AudioObject[] clip)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            if (i == clip.Length - 1)
            {
                EndOfProcess();
            }
            PC_UI.Instance.ClearSubtitle();
            yield return new WaitForSeconds(0.2f);
            Vocals.Instance.Say(clip[i]);
            yield return new WaitForSeconds(clip[i].clip != null ? clip[i].clip.length : clip[i].subtitle.Length * 0.4f);
        }
        PC_UI.Instance.ClearSubtitle();
    }
    protected virtual void EndOfProcess()
    {

    }
}
