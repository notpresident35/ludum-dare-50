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

			if (!CurrentHero.Attack())
			{
				CurrentHero.Move();
			}

			foreach (MonsterInstance monster in CurrentMonsters)
			{
				if (monster == null)
				{
					return;
				}

				if (!monster.Attack())
				{

					monster.Move();
				}
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
