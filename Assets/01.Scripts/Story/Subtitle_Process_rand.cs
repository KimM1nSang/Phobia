using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle_Process_rand : SubtitleProcess
{
	public float time = 0;
	public override void Processing()
	{
		base.Processing();
	}
	public void ProcessingRand()
	{
		StartCoroutine(ProcessRand(audioObjects));
	}
	public IEnumerator ProcessRand(AudioObject[] clip)
	{
		PC_UI.Instance.ClearSubtitle();
		yield return new WaitForSeconds(0.2f);
		int index = Random.Range(0, clip.Length);
		Vocals.Instance.Say(clip[index]);
		yield return new WaitForSeconds(clip[index].clip != null ? clip[index].clip.length : clip[index].subtitle.Length * 0.4f);
	}
	protected override IEnumerator Process(AudioObject[] clip)
	{
		return base.Process(clip);
	}
	protected override void StartOfEndProcess()
	{
		base.StartOfEndProcess();
	}
	private void OnTriggerStay(Collider other)
	{
		time += Time.deltaTime;
		if (5<= time)
		{
			ProcessingRand();
			time = 0f;
		}

	}
	private void OnTriggerExit(Collider other)
	{
		time = 0;
		PC_UI.Instance.ClearSubtitle();
	}
}
