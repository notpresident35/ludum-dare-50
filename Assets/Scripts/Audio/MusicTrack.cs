using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{

	public MusicData data;

	AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	public void SetEnabled(float intensity)
	{
		bool isEnabled = false;
		foreach (RangedFloat range in data.Ranges)
		{
			isEnabled = isEnabled || range.IsValidValue(intensity);
		}
		source.volume = isEnabled ? 1 : 0;
	}
}
