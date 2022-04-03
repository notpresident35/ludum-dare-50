using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class GameManager : MonoBehaviour
	{

		public AnimationCurve IntensityCurve;

		private AudioManager audioManager;
		private FactoryManager factoryManager;

		void Awake()
		{
			audioManager = GameObject.FindObjectOfType<AudioManager>();
			factoryManager = GameObject.FindObjectOfType<FactoryManager>();
		}

		void Update()
		{
			float intensity = IntensityCurve.Evaluate(Mathf.Min(Time.time, IntensityCurve.keys[IntensityCurve.length - 1].time));
			audioManager.SetMusicIntensity(intensity);
			factoryManager.SetSpawnIntensity(intensity);
		}
	}
}
