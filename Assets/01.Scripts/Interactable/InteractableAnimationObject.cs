using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimationObject : InteractableObjectForQuest
{
	private Animation animation;
	public AnimationClip clip;
	private void Start()
	{
		animation = GameManager.instance.player.GetComponent<Animation>();
		animation.clip = clip;

	}
	public override void Interaction()
	{
		base.Interaction();
		animation.Play();
		StartCoroutine(AnimationEndCheck());
	}
	IEnumerator AnimationEndCheck()
	{
		while (true)
		{
			if (animation.isPlaying)
			{
				PC_UI.Instance.UpProgress(QuestId);
				yield break;
			}
			yield return null;
		}
	}
}
