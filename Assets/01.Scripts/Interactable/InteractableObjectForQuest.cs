using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectForQuest : InteractableObject
{
    public string QuestId = "";
    public override void Interaction()
    {
        base.Interaction();
        if (QuestId != "")
        {
            PC_UI.Instance.AddQuestId(QuestId);
            GetComponent<SubtitleProcess>().Processing();
        }
        else
        {
            Debug.LogError("퀘스트 아이디가 없습니다");
        }
    }
}
