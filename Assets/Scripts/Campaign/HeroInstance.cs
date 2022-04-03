using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameJam
{
	public class HeroInstance : Instanceable
	{
		public Hero hero;

		public override void Spawn()
		{
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hero.sprite;
			health = hero.Health;
		}

		public override void Move()
		{
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, hero.Size, hero.FriendlyMask);

			if (!cols.Any(x => x.gameObject != gameObject))
			{
				transform.position += Vector3.up * hero.Speed * Time.deltaTime;
			}
		}

		public override bool Attack()
		{
			Collider2D col = Physics2D.OverlapCircle(transform.position, hero.Size * 1.25f, hero.AttackMask);
			if (col != null && col.transform.GetComponent<Health>())
			{
				col.transform.GetComponent<Health>().Damage(hero.Damage * Time.deltaTime);
				return true;
			}
			return false;
		}

		public override void Die()
		{
			base.Die();
			track.DetachHero();
			Destroy(gameObject);
		}
	}
}
