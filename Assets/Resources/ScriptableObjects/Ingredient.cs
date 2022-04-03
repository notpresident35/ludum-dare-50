using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
	public char Abbreviation;
	public int Frequency;
	[Range(0, 5)]
	public float GravityModifier;
	public GameObject FallingPrefab;
}
