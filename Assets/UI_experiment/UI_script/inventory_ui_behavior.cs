using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameJam
{
	public class inventory_ui_behavior : MonoBehaviour
	{
		private Bucket bucket;
		private inventory_ui inventory;
		private Transform ingredient_slot; //itemslotTemplate
		private Transform each_slot;//itemslotContainer

		private void Awake()
		{
			ingredient_slot = transform.Find("ingredient_slot");
			each_slot = ingredient_slot.Find("each_slot");


		}


		public void Setinventory(inventory_ui inventory)
		{
			this.inventory = inventory;
			Refresh_Bucket();
		}
		private void Refresh_Bucket()
		{
			int x = 0;
			int y = 0;
			float slotCellSize = .4f;
			foreach (Sprite item in inventory.Getitem())
			{   //template first, container next
				Sprite MonsterBodyPart = item; 
				MonsterBodyPart.
				Transform Bucket_background_trasform = Instantiate(each_slot, ingredient_slot).GetComponent<Transform>();
				Bucket_background_trasform.gameObject.SetActive(true);
				Bucket_background_trasform.localPosition = new Vector2(x * slotCellSize, y * slotCellSize);
				x++;
				if (x > 2)
				{
					x = 2;
					y--;
				}
			}
		}
	}
}
//1. don't know how to show the Icon, couldn't located it 
//2. don't know how to add ingredient to buckets
//3. where to place the bucket? 