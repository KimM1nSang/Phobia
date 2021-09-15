using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDragObject : InteractableObject
{
	private bool canRotate = false;

	protected override void Awake()
	{
		base.Awake();
	}
	public override void Interaction()
	{
		base.Interaction();
		GameManager.instance.canLook = false;
		canRotate = true;
	}
	protected override void Update()
	{
		base.Update();
		if (IsViewPlayer())
		{
			Debug.Log("N");
		}
			  //
			  //if(canRotate && !PlayerInput.instance.interactUp)
			  //	transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
			if (canRotate && !PlayerInput.instance.interactUp)
		{

			Vector3 dir = (GameManager.instance.player.transform.position - transform.parent.parent.position).normalized;
			Debug.Log(dir);

			//Debug.Log(Vector3.Angle(transform.parent.parent.forward, dir));
			if (Vector3.Angle(transform.parent.parent.forward, dir) > 90f)
			{
				//Debug.Log("¾Õ");
				if (!(IsViewPlayer() && PlayerInput.instance.mouseY < 0))
				{
					transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + -PlayerInput.instance.mouseY, 0, 90), 0);
				}
			}
			else
			{
				if (!(IsViewPlayer() && PlayerInput.instance.mouseY < 0))
				{
					transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
				}
				
			}
		}
			
		if (PlayerInput.instance.interactUp&& canRotate)
		{
			canRotate = false;
			GameManager.instance.canLook = true;
		}
	}
	public bool IsViewPlayer()
	{
		bool isView = false;
		RaycastHit hit;
		Vector3 dir = (GameManager.instance.player.transform.position - transform.position).normalized;
		Debug.DrawRay(transform.position, dir, Color.red, 0.1f);
		if (Physics.Raycast(transform.position, dir, out hit, 0.7f))
		{
			isView = hit.collider.gameObject.CompareTag("Player");
		}

		return isView;
	}
	//void OnDrawGizmos()
	//{
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawWireCube(transform.position + new Vector3(0,transform.position.y/2,0), meshSize.size);
	//}
}
