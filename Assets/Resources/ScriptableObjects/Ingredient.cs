using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Ingredient")]
public class Ingredient : ScriptableObject
{
    public char Abbreviation;
    public int Frequency;
    [Range(0, 4)]
    public float GravityModifier;
    public GameObject FallingPrefab;
}
