using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam{


	public class item_ui
	{
		public enum ItemType
		{
			slime,
			fire,
			bone,
			meat,
			toxin
		}
		public ItemType itemType;
		public int amount;
		public int Count()
		{
			return amount;
		}

	}
}
