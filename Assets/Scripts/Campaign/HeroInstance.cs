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

		public override bool TryMove(Transform potentialBlocker)
		{
			float amountToMove = entity.Speed * Time.deltaTime;

			// Make sure hero isn't blocked, if there's a monster on the track
			if (potentialBlocker != null)
			{
				Instanceable blockerInstance = potentialBlocker.GetComponent<Instanceable>();
				float frontEdgeOfBlockingMonster = potentialBlocker.transform.position.y - blockerInstance.entity.Size;
				float frontEdgeOfSelf = transform.position.y + entity.Size;
				if (frontEdgeOfBlockingMonster < frontEdgeOfSelf + amountToMove)
				{
					return false;
				}
			}

			transform.position += Vector3.up * amountToMove;
			return true;
		}

		public override bool Attack(Health health)
		{
			return health.Damage(entity.Damage * Time.deltaTime);
		}

		public override void Die()
		{
			// TODO: Assign new hero data and RESPAWN :)
		}
	}
}
