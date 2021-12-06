using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleProcess_6 : SubtitleProcess
{
	public override void Processing()
	{
		base.Processing();
	}
	protected override IEnumerator Process(AudioObject[] clip)
	{
		return base.Process(clip);
	}
	protected override void EndOfProcess()
	{
		base.EndOfProcess();
		GameManager.instance.canMove = true;
		GetComponent<InteractableObject>().canInteract = false;
	}
}
