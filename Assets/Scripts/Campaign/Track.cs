using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
				if (CurrentHero.Attack(CurrentMonsters[0]?.GetComponent<Health>()))
				{
					CurrentMonsters.RemoveAt(0);
				}
			}

			/* 
			FIRST MONSTER
			*/
			if (CurrentMonsters.Count > 0 && CurrentMonsters[0] != null)
			{
				if (!CurrentMonsters[0].TryMove(CurrentHero?.transform))
				{
					if (CurrentMonsters[0].Attack(CurrentHero?.GetComponent<Health>()))
					{
						CurrentHero = null;
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
