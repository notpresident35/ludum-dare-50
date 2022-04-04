using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class CampaignManager : MonoBehaviour
	{

		public Transform TrackSpawnpoint;
		public List<Track> Tracks;

		[Header("Prefabs")]
		public GameObject HeroPrefab;
		public GameObject MonsterPrefab;
		public GameObject TrackPrefab;

		Hero[] heroPool;

		private void Awake()
		{
			heroPool = Resources.LoadAll<Hero>("ScriptableObjects/Heroes");
		}

		// Returns new track ID
		public int AddTrack()
		{
			Track newTrack = Instantiate(TrackPrefab, TrackSpawnpoint.position, Quaternion.identity, transform).GetComponent<Track>();
			Tracks.Add(newTrack);
			return Tracks.IndexOf(newTrack);
		}

		public void SpawnHero(int trackID, Hero hero)
		{
			if (trackID == -1)
			{
				Debug.LogError("Tried to spawn hero with invalid track id!");
				return;
			}
			if (hero == null)
			{
				Debug.Log("Did not spawn hero - reference was null");
				return;
			}
			HeroInstance newHero = Instantiate(HeroPrefab, Tracks[trackID].HeroSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<HeroInstance>();
			newHero.entity = hero;
			newHero.Spawn();
			Tracks[trackID].AttachHero(newHero);
			print("Spawned Hero: " + newHero.name);
		}

		public void SpawnRandomHero(int trackID)
		{
			SpawnHero(trackID, heroPool[Random.Range(0, heroPool.Length)]);
		}

		public void SpawnMonster(int trackID, Monster monster)
		{
			if (trackID == -1)
			{
				Debug.LogError("Tried to spawn monster with invalid track id!");
				return;
			}
			if (monster == null)
			{
				Debug.Log("Did not spawn monster - reference was null");
				return;
			}
			MonsterInstance newMonster = Instantiate(MonsterPrefab, Tracks[trackID].MonsterSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<MonsterInstance>();
			newMonster.transform.parent = Tracks[trackID].transform;
			newMonster.entity = monster;
			newMonster.Spawn();
			Tracks[trackID].AttachMonster(newMonster);
			print("Spawned Monster: " + newMonster.name);
		}
	}
}
