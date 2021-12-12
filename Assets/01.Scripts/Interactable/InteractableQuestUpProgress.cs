using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableQuestUpProgress : InteractableObjectForQuest
{
	public override void Interaction()
	{
		base.Interaction();
		PC_UI.Instance.UpProgress(QuestId);
		if (PC_UI.Instance.questIds.Find((x) => x == QuestId) == null)
		{
			//PC_UI.Instance.AddQuestId(QuestId);
			//PC_UI.Instance.RefreshQuestList();
			//GetComponent<SubtitleProcess>().Processing();
			//PC_UI.Instance.PopUpQuestBox(true);
			
		}
		//PC_UI.Instance.UpProgress(QuestId);
		//PC_UI.Instance.RefreshQuestList();
	}
}
