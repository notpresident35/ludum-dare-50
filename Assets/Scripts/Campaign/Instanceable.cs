using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public abstract class Instanceable : Health
	{
		public Track track;
		public TrackEntity entity;
		public abstract void Spawn();
		public abstract void TryMove(Transform potentialBlocker);
		public abstract void Attack(Health health);

	}
}
