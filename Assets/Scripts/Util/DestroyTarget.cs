using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class DestroyTarget : MonoBehaviour
	{
		public UnityEngine.Object target;

		public void Execute()
		{
			Destroy(target);
		}
	}
}