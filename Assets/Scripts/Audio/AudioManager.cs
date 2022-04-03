using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameJam
{
	public class AudioManager : MonoBehaviour
	{

		public AudioMixer Mixer;
		public GameObject SFXPlayerPrefab;

		float musicIntensity = 0;
		float slowingEffect;
		List<MusicTrack> musicTracks;
		Queue<GameObject> SFXPlayerPool;

		private void Awake()
		{
			musicTracks = new List<MusicTrack>();
			foreach (Transform child in transform)
			{
				musicTracks.Add(child.GetComponent<MusicTrack>());
			}
			SFXPlayerPool = new Queue<GameObject>();
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

		public void PlaySoundEffect(AudioClip clip, float volume = 1, float pitch = 1)
		{
			GameObject player;
			if (SFXPlayerPool.Peek())
			{
				player = SFXPlayerPool.Dequeue();
			}
			else
			{
				player = Instantiate(SFXPlayerPrefab, Vector3.zero, Quaternion.identity, transform);
			}

			AudioSource playerSource = player.GetComponent<AudioSource>();

			playerSource.clip = clip;
			playerSource.volume = volume;
			playerSource.pitch = pitch;

			playerSource.Play();

			player.GetComponent<SoundEffect>().CompleteCallback += PoolSFXPlayer;
		}

		public void PoolSFXPlayer(GameObject player)
		{
			SFXPlayerPool.Enqueue(player);
		}
	}
}
