using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleProcess_2 : SubtitleProcess
{
    [SerializeField]
    private GameObject storyObject;

    protected override void StartOfEndProcess()
    {
        base.StartOfEndProcess();
        storyObject.SetActive(!storyObject.activeSelf);
        PC_UI.Instance.PopUpQuestBox(true);
        PC_UI.Instance.RefreshQuestList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Processing();
    }
}
