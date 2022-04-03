using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class MonsterInstance : Instanceable
	{

		public override void Spawn()
		{
			transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = entity.sprite;
			health = entity.Health;
		}

		public override void TryMove(Transform potentialBlocker)
		{
			Instanceable blockerInstance = potentialBlocker.GetComponent<Instanceable>();
			float backEdgeOfBlockingMonster = potentialBlocker.transform.position.y + blockerInstance.entity.Size;
			float frontEdgeOfSelf = transform.position.y - entity.Size;
			float amountToMove = -entity.Speed * Time.deltaTime;
			if (backEdgeOfBlockingMonster <= frontEdgeOfSelf + amountToMove)
			{
				transform.position += Vector3.up * amountToMove;
			}
		}

		public override void Attack(Health health)
		{
			health.Damage(entity.Damage * Time.deltaTime);
		}
	}
}
