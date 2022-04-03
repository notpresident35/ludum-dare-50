using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class GameManager : MonoBehaviour
	{

		public AnimationCurve IntensityCurve;

		private AudioManager audioManager;

		void Awake()
		{
			audioManager = GameObject.FindObjectOfType<AudioManager>();
		}

		void Update()
		{
			float intensity = Mathf.Min(IntensityCurve.Evaluate(Time.time), 1);
			audioManager.SetMusicIntensity(intensity);
		}
	}
}
