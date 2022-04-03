using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void SFXComplete();
public class SoundEffect : MonoBehaviour
{
	public Action<GameObject> CompleteCallback;
	AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (!source.isPlaying)
		{
			CompleteCallback?.Invoke(gameObject);
		}
	}
}
