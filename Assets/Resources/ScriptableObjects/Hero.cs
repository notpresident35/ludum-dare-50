using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Hero")]
public class Hero : ScriptableObject
{
    public float Health;
    public float Speed;
    public Sprite sprite;
}
