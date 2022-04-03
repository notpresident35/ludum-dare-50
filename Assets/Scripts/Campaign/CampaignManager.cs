using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class CampaignManager : MonoBehaviour
	{
		public List<Track> Tracks;

		[Header("Prefabs")]
		public GameObject HeroPrefab;
		public GameObject MonsterPrefab;
		public GameObject TrackPrefab;

		// Testing
		private void Start()
		{
			AddTrack();
		}

		public void AddTrack()
		{
			Track newTrack = Instantiate(TrackPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Track>();
			Tracks.Add(newTrack);
		}

		public void SpawnHero(int trackID, Hero hero)
		{
			HeroInstance newHero = Instantiate(HeroPrefab, Tracks[trackID].HeroSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<HeroInstance>();
			newHero.entity = hero;
			newHero.Spawn();
			Tracks[trackID].AttachHero(newHero);
		}

		public void SpawnMonster(int trackID, Monster monster)
		{
			MonsterInstance newMonster = Instantiate(MonsterPrefab, Tracks[trackID].MonsterSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<MonsterInstance>();
			newMonster.transform.parent = Tracks[trackID].transform;
			newMonster.entity = monster;
			newMonster.Spawn();
			Tracks[trackID].AttachMonster(newMonster);
		}
	}
}
