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

		public override bool TryMove(Transform potentialBlocker)
		{
			float amountToMove = -entity.Speed * Time.deltaTime;

			// Make sure monster isn't blocked, if there's a hero on the track
			if (potentialBlocker != null)
			{
				Instanceable blockerInstance = potentialBlocker.GetComponent<Instanceable>();
				float backEdgeOfBlockingMonster = potentialBlocker.transform.position.y + blockerInstance.entity.Size;
				float frontEdgeOfSelf = transform.position.y - entity.Size;
				if (backEdgeOfBlockingMonster > frontEdgeOfSelf + amountToMove)
				{
					return false;
				}
			}
			transform.position += Vector3.up * amountToMove;
			return true;
		}

		public override bool Attack(Health health)
		{
			bool killed = health.Damage(entity.Damage);
			if (killed)
			{
				AudioManager.Instance.PlaySoundEffect(health.GetComponent<Instanceable>().entity.DeathSFX);
			}
			else
			{
				AudioManager.Instance.PlaySoundEffect(entity.AttackSFX[Random.Range(0, entity.AttackSFX.Length)]);
			}
			return killed;
		}
	}
}
