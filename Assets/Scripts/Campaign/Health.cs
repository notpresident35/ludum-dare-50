using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class Health : MonoBehaviour
	{

		public float health;

		public void Damage(float amount)
		{
			//print(gameObject.name + " was attacked");
			health -= amount;
			if (health <= 0)
			{
				Die();
			}
		}

		public void Heal(float amount)
		{
			health += amount;
		}

		public virtual void Die()
		{

		}
	}
}
