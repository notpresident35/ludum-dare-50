using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Monster")]
public class Monster : ScriptableObject
{

    public float Health;
    public float Damage;
    public float Size;
    public float Speed;
    public List<string> Recipes;
    public Sprite sprite;
    public LayerMask AttackMask;
    public LayerMask FriendlyMask;
}
