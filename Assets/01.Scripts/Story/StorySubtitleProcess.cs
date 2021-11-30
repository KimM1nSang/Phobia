using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySubtitleProcess : MonoBehaviour
{
    [SerializeField]
    private AudioObject[] audioObjects;
    
    public void StoryProcess()
    {
        StartCoroutine(Process(audioObjects));
    }

    private IEnumerator Process(AudioObject[] clip)
    {
        Destroy(GetComponent<BoxCollider>());

        for (int i = 0; i < clip.Length; i++)
        {
            if(i == clip.Length - 1)
            {
                EndOfProcess();
            }
            Vocals.Instance.Say(clip[i]);
            yield return new WaitForSeconds(clip[i].clip != null ? clip[i].clip.length : clip[i].subtitle.Length * 0.4f);
        }
        PC_UI.Instance.ClearSubtitle();

    }
    private void EndOfProcess()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StoryProcess();
    }
}
