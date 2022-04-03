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

		public void DetachHero()
		{
			CurrentHero = null;
		}

		public void AttachMonster(MonsterInstance monster)
		{
			CurrentMonsters.Add(monster);
			monster.track = this;
		}

		public void DetachMonster(MonsterInstance monster)
		{
			CurrentMonsters.Remove(monster);
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
				if (!monster.Attack())
				{
					monster.Move();
				}
			}
		}
	}
}
