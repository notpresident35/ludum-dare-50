using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInstance : Health
{
    public Hero hero;

    public void Spawn() {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hero.sprite;
    }

    public void Move() {

    }

    public void Attack() {
        
    }
}
