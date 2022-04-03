using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	[CreateAssetMenu(menuName ="MyGame/Player Avatar Config")]
	public class PlayerAvatarConfig : ScriptableObject
	{
		[Header("Walk")]
		public float walkHorzMax = 8;
		public float walkHorzAccel = 50;
	}
}