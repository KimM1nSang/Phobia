using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : InteractableObject
{

	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.canLook = false;
		transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y+PlayerInput.instance.mouseY,0,90), 0);
	}
}
