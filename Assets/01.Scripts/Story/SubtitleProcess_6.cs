using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleProcess_6 : SubtitleProcess
{
	public GameObject darkZone;
	public override void Processing()
	{
		base.Processing();
	}
	protected override IEnumerator Process(AudioObject[] clip)
	{
		return base.Process(clip);
	}
	protected override void StartOfEndProcess()
	{
		base.StartOfEndProcess();
		GameManager.instance.canMove = true;
		GetComponent<InteractableObject>().canInteract = false;
	}
	protected override void EndOfEndProcess()
	{
		base.EndOfEndProcess();
		if (darkZone != null)
		{
			darkZone.SetActive(true);
			StartCoroutine(GetComponent<VolumeSc>().VolumeFade());
		}
	}
}
