using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class Health : MonoBehaviour
	{

		public float health;

		// Returns true if killed by damage
		public bool Damage(float amount)
		{
			//print(gameObject.name + " was attacked");
			health -= amount;
			if (health <= 0)
			{
				Die();
				return true;
			}
			return false;
		}

		public void Heal(float amount)
		{
			health += amount;
		}

		public virtual void Die()
		{
			Destroy(gameObject);
		}
	}
}
