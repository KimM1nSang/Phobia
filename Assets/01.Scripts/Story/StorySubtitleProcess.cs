using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySubtitleProcess : MonoBehaviour
{
    [SerializeField]
    private AudioObject[] audioObjects;

    [SerializeField]
    private GameObject storyObject;
    
    public void StoryProcess()
    {
        PC_UI.Instance.PopUpToDoBox(true);
        StartCoroutine(Process(audioObjects));
    }

    private IEnumerator Process(AudioObject[] clip)
    {
        if (GetComponent<BoxCollider>() != null)
            Destroy(GetComponent<BoxCollider>());

        for (int i = 0; i < clip.Length; i++)
        {
            if(i == clip.Length - 1)
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
    private void EndOfProcess()
    {
        storyObject.SetActive(!storyObject.activeSelf);
        PC_UI.Instance.PopUpToDoBox(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StoryProcess();
    }
}
