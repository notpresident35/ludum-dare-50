using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Monster")]
public class Monster : ScriptableObject
{
    public List<string> Recipes;
    public Sprite sprite;
}
