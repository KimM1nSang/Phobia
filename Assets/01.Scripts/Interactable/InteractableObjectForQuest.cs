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
            Debug.LogError("����Ʈ ���̵� �����ϴ�");
        }
    }
}
