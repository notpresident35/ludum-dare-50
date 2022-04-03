using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class IngredientDestroyer : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			var script = collision.GetComponent<FallingIngredient>();
			if (script != null)
			{
				script.Delete();
			}
		}
	}
}