using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIngredient : MonoBehaviour
{

	public Ingredient ingredient;

	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = ingredient.GravityModifier;
	}

	// Uncomment for live tuning
	/*
	void Update()
	{
		rb.gravityScale = ingredient.GravityModifier;
	}*/
}
