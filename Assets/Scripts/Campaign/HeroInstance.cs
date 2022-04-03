using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameJam
{
	public class HeroInstance : Instanceable
	{

		public override void Spawn()
		{
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = entity.sprite;
			health = entity.Health;
		}

		public override void TryMove(Transform potentialBlocker)
		{
			Instanceable blockerInstance = potentialBlocker.GetComponent<Instanceable>();
			float frontEdgeOfBlockingMonster = potentialBlocker.transform.position.y - blockerInstance.entity.Size;
			float frontEdgeOfSelf = transform.position.y + entity.Size;
			float amountToMove = entity.Speed * Time.deltaTime;
			if (frontEdgeOfBlockingMonster >= frontEdgeOfSelf + amountToMove)
			{
				transform.position += Vector3.up * amountToMove;
			}
		}

		public override void Attack(Health health)
		{
			health.Damage(entity.Damage * Time.deltaTime);
		}

		public override void Die()
		{
			// TODO: Assign new hero data and RESPAWN :)
		}
	}
}
