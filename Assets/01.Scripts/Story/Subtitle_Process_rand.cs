using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle_Process_rand : SubtitleProcess
{
	public override void Processing()
	{
		base.Processing();
	}
	public IEnumerator ProcessRand(AudioObject[] clip)
	{
		PC_UI.Instance.ClearSubtitle();
		yield return new WaitForSeconds(0.2f);
		Vocals.Instance.Say(clip[Random.Range(0, clip.Length)]);
	}
	protected override IEnumerator Process(AudioObject[] clip)
	{
		return base.Process(clip);
	}
	protected override void EndOfProcess()
	{
		base.EndOfProcess();
	}
}
