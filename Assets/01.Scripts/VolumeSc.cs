using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeSc : MonoBehaviour
{
	public Volume volume;
	public Volume blackWhite;

	private void Start()
	{
		blackWhite = GameObject.Find("black white").GetComponent<Volume>();
	}
	public IEnumerator VolumeFade(float maxTime = 1f)
	{
		float time = 0;

		float nowWeight = blackWhite.weight;
		while (true)
		{
			time +=Time.deltaTime;
			blackWhite.weight = Mathf.Lerp(nowWeight, nowWeight + 0.2f, time / maxTime);
			volume.weight = Mathf.Lerp(0f, 1f, time / maxTime);
			if (time >= maxTime)
			{
				yield break;
			}
			yield return null;
		}

	}
}
