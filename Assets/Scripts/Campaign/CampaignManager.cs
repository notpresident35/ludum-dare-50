using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignManager : MonoBehaviour
{
    public List<Track> Tracks;

    [Header("Prefabs")]
    public GameObject HeroPrefab;
    public GameObject MonsterPrefab;
    public GameObject TrackPrefab;

    private void Start() {
        AddTrack();
        SpawnMonster(0, "Creature");
    }

    public void AddTrack () {
        Track newTrack = Instantiate(TrackPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Track>();
        Tracks.Add(newTrack);
        SpawnHero (Tracks.Count - 1, "Default");
    }

    public void SpawnHero (int trackID, string heroName) {
        HeroInstance newHero = Instantiate(HeroPrefab, Tracks[trackID].HeroSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<HeroInstance>();
        newHero.hero = Resources.Load<Hero>("ScriptableObjects/Heroes/" + heroName);
        newHero.Spawn();
    }

    public void SpawnMonster (int trackID, string monsterName) {
        MonsterInstance newMonster = Instantiate(MonsterPrefab, Tracks[trackID].MonsterSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<MonsterInstance>();
        newMonster.transform.parent = Tracks[trackID].transform;
        newMonster.monster = Resources.Load<Monster>("ScriptableObjects/Monsters/" + monsterName);
        newMonster.Spawn();
    }
}
