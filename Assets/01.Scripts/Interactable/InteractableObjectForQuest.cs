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
            if (PC_UI.Instance.questIds.Find((x)=>x==QuestId)==null)
            PC_UI.Instance.AddQuestId(QuestId);
            //����Ʈ �߰��ϰ� ���� �� ������ �߰� �ȵ�����
            GetComponent<SubtitleProcess>().Processing();
        }
        else
        {
            Debug.LogError("����Ʈ ���̵� �����ϴ�");
        }
    }
}
