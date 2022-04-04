using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public static class UXHelper
	{
		/// <summary>
		/// Pressing "Use" will interact with this object. Null if no target object.
		/// </summary>
		public static GameObject TargetInteractable { get; set; }
	}
}