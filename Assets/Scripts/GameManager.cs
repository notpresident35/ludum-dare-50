using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class GameManager : MonoBehaviour
	{

		public AnimationCurve IntensityCurve;

		public GameObject BucketPrefab;
		public GameObject BucketUXPrefab;
		public GameObject GameOverUI;

		private AudioManager audioManager;
		private FactoryManager factoryManager;
		private CampaignManager campaignManager;

		void Awake()
		{
			audioManager = GameObject.FindObjectOfType<AudioManager>();
			factoryManager = GameObject.FindObjectOfType<FactoryManager>();
			campaignManager = GameObject.FindObjectOfType<CampaignManager>();
			GameState.state = GameState.State.MainGame;
		}


		void Start()
		{
			campaignManager.CampaignFailed.AddListener(GameOver);

			// TODO: Replace with tutorial
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

			Bucket newBucket = Instantiate(BucketPrefab, factoryManager.transform.position, Quaternion.identity, factoryManager.transform).GetComponent<Bucket>();
			newBucket.Configure(trackID);

			BucketUX newBucketUX = Instantiate(BucketUXPrefab, factoryManager.transform.position, Quaternion.identity, factoryManager.transform).GetComponent<BucketUX>();
			newBucketUX.BindBucket(newBucket);
			newBucketUX.Spawn();
		}

		public void GameOver()
		{
			print("GAME OVER");
			GameState.state = GameState.State.GameOver;
			GameOverUI.SetActive(true);
			StartCoroutine(RestartGame());
		}

		IEnumerator RestartGame()
		{
			yield return new WaitForSeconds(5);
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
		}
	}
}
