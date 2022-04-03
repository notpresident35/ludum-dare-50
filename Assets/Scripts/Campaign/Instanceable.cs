using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public abstract class Instanceable : Health
	{
		public TrackEntity entity;
		public abstract void Spawn();
		// Returns true if movement was not blocked
		public abstract bool TryMove(Transform potentialBlocker);
		// Returns true if attack scores a kill
		public abstract bool Attack(Health health);

	}
}
