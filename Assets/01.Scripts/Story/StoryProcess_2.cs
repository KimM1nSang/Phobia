using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProcess_2 : StoryProcess
{
    [SerializeField]
    private GameObject storyObject;

    protected override void EndOfProcess()
    {
        base.EndOfProcess();
        storyObject.SetActive(!storyObject.activeSelf);
        PC_UI.Instance.PopUpQuestBox(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StoryProcessing();
    }
}
