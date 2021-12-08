using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeSc : MonoBehaviour
{
	public Volume volume;

	public IEnumerator VolumeFade(float maxTime = 1f)
	{
		float time = 0;
		while (true)
		{
			time +=Time.deltaTime;
			volume.weight = Mathf.Lerp(0f, 1f, time / maxTime);
			if (time >= maxTime)
			{
				yield break;
			}
			yield return null;
		}

	}
}
