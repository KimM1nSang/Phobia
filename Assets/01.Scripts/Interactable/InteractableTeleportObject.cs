using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeleportObject : InteractableObject
{
	public Transform telPos;
	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.player.GetComponent<CharacterController>().enabled = false;
		GameManager.instance.player.transform.position = telPos.position;
		GameManager.instance.player.GetComponent<CharacterController>().enabled = true;
		//GameManager.instance.canMove = false;
	}
}
