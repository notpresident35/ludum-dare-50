using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Hero")]
public class Hero : ScriptableObject
{
    public float Health;
    public float Damage;
    public float Size;
    public float Speed;
    public Sprite sprite;
    public LayerMask AttackMask;
    public LayerMask FriendlyMask;
}
