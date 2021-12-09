using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableQuestUpProgress : InteractableObjectForQuest
{
	public override void Interaction()
	{
		base.Interaction();
		PC_UI.Instance.UpProgress(QuestId);
	}
}
