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

		AlchemyManager alchem;

		// Testing
		private void Start()
		{
			AddTrack();
			SpawnHero(0, Resources.Load<Hero>("ScriptableObjects/Heroes/Default"));
			SpawnMonster(0, Resources.Load<Monster>("ScriptableObjects/Monsters/Creature"));
			alchem = FindObjectOfType<AlchemyManager>();
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				SpawnMonster(0, alchem.GetRandomMonster());
			}
			if (Input.GetMouseButtonDown(1))
			{
				SpawnHero(0, Resources.Load<Hero>("ScriptableObjects/Heroes/Default"));
			}
		}

		public void AddTrack()
		{
			Track newTrack = Instantiate(TrackPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Track>();
			Tracks.Add(newTrack);
		}

		public void SpawnHero(int trackID, Hero hero)
		{
			HeroInstance newHero = Instantiate(HeroPrefab, Tracks[trackID].HeroSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<HeroInstance>();
			newHero.hero = hero;
			newHero.Spawn();
			Tracks[trackID].AttachHero(newHero);
		}

		public void SpawnMonster(int trackID, Monster monster)
		{
			MonsterInstance newMonster = Instantiate(MonsterPrefab, Tracks[trackID].MonsterSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<MonsterInstance>();
			newMonster.transform.parent = Tracks[trackID].transform;
			newMonster.monster = monster;
			newMonster.Spawn();
			Tracks[trackID].AttachMonster(newMonster);
		}
	}
}
