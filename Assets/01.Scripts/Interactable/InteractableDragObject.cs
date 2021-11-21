using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDragObject : InteractableObject
{
	private int doorDir = 1;
	private bool canRotate = false;
	public float doorDistance;


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

		float distance = (GameManager.instance.player.transform.position - transform.position).magnitude;
		Vector3 dir = (GameManager.instance.player.transform.position - transform.position).normalized;

		if (distance < doorDistance)
		{
			Debug.Log("N");
		}
		
		//문이 일정 각도로 이상으로 열리면 버벅 거리는거 막기위한 코드
		if (PlayerInput.instance.interact)
		{
			if (Vector3.Angle(transform.forward, dir) > 90f)
			{
				doorDir = -1;
			}
			else if (Vector3.Angle(transform.forward, dir) < 90f)
			{
				doorDir = 1;
			}
		}

		if (canRotate && !PlayerInput.instance.interactUp)
		{
			//문과 플레이어 거리가 일정량 이상 가까워 지면 플레이어 쪽으로 문을 못 당기게 막음
			if (!(distance < doorDistance && PlayerInput.instance.mouseY < 0))
			{
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + doorDir * PlayerInput.instance.mouseY, 0, 90), 0);
			}

		}
			
		if (PlayerInput.instance.interactUp&& canRotate)
		{
			canRotate = false;
			GameManager.instance.canLook = true;
		}
	}
}
