using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	[CreateAssetMenu(menuName = "MyGame/Player Avatar Config")]
	public class PlayerAvatarConfig : ScriptableObject
	{
		[Header("Walk")]
		public float walkHorzMax = 8;
		public float walkHorzAccel = 50;

		[Header("Bucket")]
		public float sameYTolerance = 0.05f;
		public GameObject assembleEffects;
	}
}
