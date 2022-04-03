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

		public void AttachHero(HeroInstance hero)
		{
			CurrentHero = hero;
			hero.track = this;
		}

		public void AttachMonster(MonsterInstance monster)
		{
			CurrentMonsters.Add(monster);
			monster.track = this;
		}

		void Update()
		{
			if (!CurrentHero)
			{
				return;
			}

			/* 
			HERO
			*/
			bool heroInRange = CurrentMonsters[0].transform.position.y <= CurrentHero.transform.position.y + CurrentHero.entity.AttackRange;

			if (heroInRange)
			{
				CurrentHero.Attack(CurrentMonsters[0].GetComponent<Health>());
			}
			else
			{
				CurrentHero.TryMove(CurrentMonsters[0].transform);
			}

			/* 
			FIRST MONSTER
			*/
			if (CurrentMonsters.Count < 1)
			{
				return;
			}

			bool monsterInRange = CurrentHero.transform.position.y <= CurrentMonsters[0].transform.position.y - CurrentMonsters[0].entity.AttackRange;

			if (monsterInRange)
			{
				CurrentMonsters[0].Attack(CurrentHero.GetComponent<Health>());
			}
			else
			{
				CurrentMonsters[0].TryMove(CurrentHero.transform);
			}


			/* 
			ALL OTHER MONSTERS
			*/
			if (CurrentMonsters.Count < 2)
			{
				return;
			}

			for (int i = 1; i < CurrentMonsters.Count; i++)
			{
				CurrentMonsters[i].TryMove(CurrentMonsters[i - 1].transform);
			}

			CleanMonsterList();
		}

		void CleanMonsterList()
		{
			for (int i = CurrentMonsters.Count; i < 0; i--)
			{
				if (CurrentMonsters[i] == null)
				{
					CurrentMonsters.RemoveAt(i);
				}
			}

		}
	}
}
