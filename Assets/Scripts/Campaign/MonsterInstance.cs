using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class MonsterInstance : Instanceable
	{

		public Monster monster;

		public override void Spawn()
		{
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = monster.sprite;
			health = monster.Health;
		}

		public override void Move()
		{
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, monster.Size * 0.5f, monster.FriendlyMask);

			if (!cols.Any(x => x.gameObject != gameObject))
			{
				transform.position += Vector3.up * -monster.Speed * Time.deltaTime;
			}
		}

		public override bool Attack()
		{
			Collider2D col = Physics2D.OverlapCircle(transform.position, monster.Size * 1.25f, monster.AttackMask);
			if (col != null && col.transform.GetComponent<Health>())
			{
				col.transform.GetComponent<Health>().Damage(monster.Damage * Time.deltaTime);
				return true;
			}
			return false;
		}

		public override void Die()
		{
			base.Die();
			Destroy(gameObject);
		}
	}
}
