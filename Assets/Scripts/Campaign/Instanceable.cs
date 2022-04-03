using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public abstract class Instanceable : Health
	{
		public Track track;
		public abstract void Spawn();
		public abstract void Move();
		public abstract bool Attack();

	}
}
