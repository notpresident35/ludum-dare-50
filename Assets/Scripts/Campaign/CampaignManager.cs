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

    // Testing
    private void Start() {
        AddTrack();
        SpawnHero(0, Resources.Load<Hero>("ScriptableObjects/Heroes/Default"));
        SpawnMonster(0, Resources.Load<Monster>("ScriptableObjects/Monsters/Creature"));
    }

    public void AddTrack () {
        Track newTrack = Instantiate(TrackPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Track>();
        Tracks.Add(newTrack);
    }

    public void SpawnHero (int trackID, Hero hero) {
        HeroInstance newHero = Instantiate(HeroPrefab, Tracks[trackID].HeroSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<HeroInstance>();
        newHero.hero = hero;
        newHero.Spawn();
    }

    public void SpawnMonster (int trackID, Monster monster) {
        MonsterInstance newMonster = Instantiate(MonsterPrefab, Tracks[trackID].MonsterSpawnpoint.position, Quaternion.identity, Tracks[trackID].transform).GetComponent<MonsterInstance>();
        newMonster.transform.parent = Tracks[trackID].transform;
        newMonster.monster = monster;
        newMonster.Spawn();
    }
}
