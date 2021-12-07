using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeleportObject : InteractableObjectForQuest
{
	public Transform telPos;
	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.player.GetComponent<CharacterController>().enabled = false;
		GameManager.instance.player.transform.position = telPos.position;
		GameManager.instance.player.GetComponent<CharacterController>().enabled = true;
		SubtitleProcess process = GetComponent<SubtitleProcess>();
		if (process != null)
		{
			GameManager.instance.canMove = false;
			PC_UI.Instance.UpProgress("PlaygroundMain");
		}
		else
		{
			GameManager.instance.fade.FadeInOut();
		}
	}
}
