using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJam
{
	public class Track : MonoBehaviour
	{

		[HideInInspector]
		public HeroInstance CurrentHero;
		[HideInInspector]
		public List<MonsterInstance> CurrentMonsters;

		public Transform MonsterSpawnpoint;
		public Transform HeroSpawnpoint;
		public Transform Nexus;

		public UnityEvent NexusReached;

		private void Awake()
		{
			CurrentMonsters = new List<MonsterInstance>();
		}

		public void AttachHero(HeroInstance hero)
		{
			CurrentHero = hero;
		}

		public void AttachMonster(MonsterInstance monster)
		{
			CurrentMonsters.Add(monster);
		}

		void Update()
		{
			// Monsters will wait around until a new hero appears if a hero dies
			if (!CurrentHero)
			{
				return;
			}

			// LOSS STATE
			if (CurrentHero.transform.position.y >= Nexus.position.y && GameState.state == GameState.State.MainGame)
			{
				NexusReached?.Invoke();
				Destroy(CurrentHero.gameObject);
			}

			/* 
			HERO
			*/
			if (CurrentMonsters.Count < 1)
			{
				CurrentHero.TryMove(null);
				return;
			}

			if (!CurrentHero.TryMove(CurrentMonsters[0]?.transform))
			{
				CurrentHero.AttackTimer += Time.deltaTime;
				if (CurrentHero.AttackTimer > CurrentHero.entity.AttackDelay)
				{
					if (CurrentHero.Attack(CurrentMonsters[0]?.GetComponent<Health>()))
					{
						CurrentHero.KillMovementTimer = CurrentHero.entity.KillMovementDelay;
						CurrentMonsters.RemoveAt(0);
					}
					CurrentHero.AttackTimer = 0;
				}
			}

			/* 
			FIRST MONSTER
			*/
			if (CurrentMonsters.Count > 0 && CurrentMonsters[0] != null)
			{
				if (!CurrentMonsters[0].TryMove(CurrentHero?.transform))
				{
					CurrentHero.AttackTimer += Time.deltaTime;
					if (CurrentHero.AttackTimer > CurrentHero.entity.AttackDelay)
					{
						if (CurrentMonsters[0].Attack(CurrentHero?.GetComponent<Health>()))
						{
							CurrentMonsters[0].KillMovementTimer = CurrentMonsters[0].entity.KillMovementDelay;
							CurrentHero = null;
						}
					}
				}
			}

			/* 
			ALL OTHER MONSTERS
			*/
			if (CurrentMonsters.Count > 1)
			{
				for (int i = 1; i < CurrentMonsters.Count; i++)
				{
					CurrentMonsters[i]?.TryMove(CurrentMonsters[i - 1]?.transform);
				}
			}
		}
	}
}
