using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeleportObject : InteractableObject
{
	public Transform telPos;
	public string QuestId = "";


	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.player.GetComponent<CharacterController>().enabled = false;
		GameManager.instance.player.transform.position = telPos.position;
		GameManager.instance.player.GetComponent<CharacterController>().enabled = true;
		if (QuestId != "")
		{
			if (PC_UI.Instance.questIds.Find((x) => x == QuestId) == null)
			{
				PC_UI.Instance.AddQuestId(QuestId);
				PC_UI.Instance.RefreshQuestList();
			}
			GetComponent<SubtitleProcess>().Processing();
			GameManager.instance.canMove = false;
			PC_UI.Instance.UpProgress(QuestId);
		}
		else
		{
			GameManager.instance.fade.FadeInOut();
		}
	}
}
