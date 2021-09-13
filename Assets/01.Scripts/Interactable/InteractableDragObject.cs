using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDragObject : InteractableObject
{
	private bool canRotate = false;
	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.canLook = false;
		canRotate = true;
	}
	protected override void Update()
	{
		base.Update();
		Debug.Log("����ȣ");
		if(canRotate && !PlayerInput.instance.interactUp)
			transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
		if (PlayerInput.instance.interactUp)
		{
			canRotate = false;
			GameManager.instance.canLook = true;
		}
	}
}
