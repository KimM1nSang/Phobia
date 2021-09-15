using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDragObject : InteractableObject
{
	private bool canRotate = false;
	private LayerMask whatIsPlayer;
	private MeshRenderer mesh;
	private Bounds meshSize;
	protected override void Awake()
	{
		base.Awake();
		mesh = GetComponent<MeshRenderer>();
		meshSize = mesh.bounds;
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
			  //Debug.Log("무야호");
			  //if(canRotate && !PlayerInput.instance.interactUp)
			  //	transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
		if (canRotate && !PlayerInput.instance.interactUp)
		{
			Vector3 dir = (GameManager.instance.player.transform.position - transform.parent.parent.position).normalized;
			Debug.Log(Vector3.Angle(transform.parent.parent.forward, dir));
			if (Vector3.Angle(transform.parent.parent.forward, dir) > 90f)
			{
				//Debug.Log("앞");
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + -PlayerInput.instance.mouseY, 0, 90), 0);
			}
			else
			{
				Debug.Log(Vector3.Angle(transform.parent.parent.forward, dir));
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
			}
		}
			
		if (PlayerInput.instance.interactUp&& canRotate)
		{
			canRotate = false;
			GameManager.instance.canLook = true;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position + new Vector3(0,transform.position.y/2,0), meshSize.size);
	}
}
