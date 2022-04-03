using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIngredient : MonoBehaviour
{
	public Ingredient ingredient;
	public GameObject destroyEffects;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = ingredient.GravityModifier;
	}

	/// <summary>
	/// Called when ingredient lands in bucket.
	/// </summary>
	public void Collect()
	{
		Destroy(gameObject);
	}

	/// <summary>
	/// Called when ingredient falls out of world.
	/// </summary>
	public void Delete()
	{
		Instantiate(destroyEffects, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
