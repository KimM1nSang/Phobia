using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectForQuest : InteractableObject
{
    public string QuestId = "";
    public AudioObject basicAudioObject = null;
    public override void Interaction()
    {
        base.Interaction();
        if(canInteract)
        {
            canInteract = false;
            if (QuestId != "")
            {
                if (PC_UI.Instance.questIds.Find((x) => x == QuestId) == null)
                {
                    PC_UI.Instance.AddQuestId(QuestId);
                }
                //퀘스트 추가하고 나서 탭 눌러도 추가 안되있음
                if(GetComponent<SubtitleProcess>()!=null)
                GetComponent<SubtitleProcess>().Processing();
            }
            else
            {
                Debug.LogError("퀘스트 아이디가 없습니다");
            }
        }
        else
        {
            Vocals.Instance.Say(basicAudioObject);
        }
        
    }
}
