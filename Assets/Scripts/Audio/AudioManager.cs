using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameJam
{
	public class AudioManager : MonoBehaviour
	{

		public AudioMixer Mixer;

		float musicIntensity = 0;
		float slowingEffect;
		List<MusicTrack> musicTracks;

		private void Awake()
		{
			musicTracks = new List<MusicTrack>();
			foreach (Transform child in transform)
			{
				musicTracks.Add(child.GetComponent<MusicTrack>());
			}
		}

		public void SetMusicIntensity(float intensity)
		{
			foreach (MusicTrack track in musicTracks)
			{
				track.SetEnabled(intensity);
			}
		}

		public void SlowEffect()
		{
			// Note: Implement later!
			// Also don't slow down time.timescale directly here - tell gamemanager to do it, so other juice effects don't conflict
		}
	}
}
