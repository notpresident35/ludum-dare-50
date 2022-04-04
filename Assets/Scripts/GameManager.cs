using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class GameManager : MonoBehaviour
	{

		public AnimationCurve IntensityCurve;

		public GameObject BucketPrefab;

		private AudioManager audioManager;
		private FactoryManager factoryManager;
		private CampaignManager campaignManager;

		void Awake()
		{
			audioManager = GameObject.FindObjectOfType<AudioManager>();
			factoryManager = GameObject.FindObjectOfType<FactoryManager>();
			campaignManager = GameObject.FindObjectOfType<CampaignManager>();
		}

		// TODO: Remove, this is only for testing
		void Start()
		{
			SpawnTrack();
		}

		void Update()
		{
			float intensity = IntensityCurve.Evaluate(Mathf.Min(Time.time, IntensityCurve.keys[IntensityCurve.length - 1].time));
			audioManager.SetMusicIntensity(intensity);
			factoryManager.SetSpawnIntensity(intensity);
		}

		public void SpawnTrack()
		{
			int trackID = campaignManager.AddTrack();
			campaignManager.SpawnRandomHero(trackID);

			GameObject newBucket = Instantiate(BucketPrefab, factoryManager.transform.position, Quaternion.identity, factoryManager.transform);
			newBucket.GetComponent<Bucket>().Configure(trackID);
			// TODO:
			/*
			var bucketUi Instantiate(BucketUI)
			bucketUi.Bind(bucket)

			*/
		}
	}
}
