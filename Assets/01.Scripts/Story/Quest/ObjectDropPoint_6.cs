using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropPoint_6 : ObjectDropPoint
{
	public override void OnDropObject()
	{
		base.OnDropObject();
		StartCoroutine(StageQuest_6.Instance.HumanOn("Stand", 0.5f));
		//gameObject.SetActive(false);
	}
}
