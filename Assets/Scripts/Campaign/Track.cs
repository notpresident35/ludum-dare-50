using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    
    [HideInInspector]
    public HeroInstance CurrentHero;
    [HideInInspector]
    public List<MonsterInstance> CurrentMonsters;

    public Transform MonsterSpawnpoint;
    public Transform HeroSpawnpoint;

    public void AttachHero (HeroInstance hero) {
        CurrentHero = hero;
    }

    void Update(){
        CurrentHero.Move();

        foreach (MonsterInstance monster in CurrentMonsters) {
            monster.Move();
        }
        
        CurrentHero.Attack();

        foreach (MonsterInstance monster in CurrentMonsters) {
            monster.Attack();
        }
    }
}
