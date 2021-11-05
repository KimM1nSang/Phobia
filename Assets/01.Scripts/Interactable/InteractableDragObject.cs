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
		
		//���� ���� ������ �̻����� ������ ���� �Ÿ��°� �������� �ڵ�
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

<<<<<<< HEAD
=======
		if (canRotate && !PlayerInput.instance.interactUp)
		{
			//���� �÷��̾� �Ÿ��� ������ �̻� ����� ���� �÷��̾� ������ ���� �� ���� ����
			if (!(distance < doorDistance && PlayerInput.instance.mouseY < 0))
			{
				transform.parent.rotation = Quaternion.Euler(0, Mathf.Clamp(transform.parent.rotation.eulerAngles.y + doorDir * PlayerInput.instance.mouseY, 0, 90), 0);
			}

		}
			
>>>>>>> b731b4514695e1cb152dc9f8534b1fd319928266
		if (PlayerInput.instance.interactUp&& canRotate)
		{
			canRotate = false;
			GameManager.instance.canLook = true;
		}
	}
}
