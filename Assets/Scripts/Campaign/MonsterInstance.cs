using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstance : Health
{

    public Monster monster;

    public void Spawn() {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = monster.sprite;
    }

    public void Move() {
        
    }

    public void Attack() {
        
    }
}
