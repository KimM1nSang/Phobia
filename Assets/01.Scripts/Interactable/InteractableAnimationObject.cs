using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimationObject : InteractableObjectForQuest
{
	private Animation animation;
	public AnimationClip clip;
	public Animation objAnimation;
	public AnimationClip objAnimationClip;
	private void Start()
	{
		animation = GameManager.instance.player.GetComponent<Animation>();

	}
	public override void Interaction()
	{
		base.Interaction();
		AnimationPlay(animation, clip);
		AnimationPlay(objAnimation, objAnimationClip);
	}
	IEnumerator AnimationEndCheck(Animation _animation)
	{
		while (true)
		{
			if (_animation.isPlaying)
			{
				PC_UI.Instance.UpProgress(QuestId);
				yield break;
			}
			yield return null;
		}
	}
	private void AnimationPlay(Animation _animation, AnimationClip _clip)
	{
		if (_clip != null)
		{
			_animation.clip = _clip;
			_animation.Play();
			StartCoroutine(AnimationEndCheck(_animation));
		}
	}
}
