using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInstance : MonoBehaviour
{

    public Monster monster;

    public void Spawn() {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = monster.sprite;
    }
}
