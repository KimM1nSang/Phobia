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
<<<<<<< HEAD
		Debug.Log("¹«¾ßÈ£");
		if(canRotate && !PlayerInput.instance.interactUp)
			transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
		if (PlayerInput.instance.interactUp && canRotate)
=======
		if (Physics.OverlapBox(transform.position, meshSize.size, Quaternion.identity, whatIsPlayer) != null)
		{
			Debug.Log(Physics.OverlapBox(transform.position * transform.position.y, meshSize.size, Quaternion.identity, whatIsPlayer).Length);
		}
		if (canRotate && !PlayerInput.instance.interactUp)
		{
			Vector3 dir = (GameManager.instance.player.transform.position - transform.position).normalized;

			if (Vector3.Angle(transform.forward, dir) > 90f)
			{
				Debug.Log("A");
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + -PlayerInput.instance.mouseY, 0, 90), 0);
			}
			else
			{
				Debug.Log(Vector3.Angle(transform.forward, dir));
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + PlayerInput.instance.mouseY, 0, 90), 0);
			}
		}
			
		if (PlayerInput.instance.interactUp&& canRotate)
>>>>>>> 06c4efa07aefe6696ecc1e65f97fb4dff5c2ed6f
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
