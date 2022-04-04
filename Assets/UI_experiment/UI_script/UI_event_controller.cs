using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameJam
{
	public class UI_event_controller : MonoBehaviour
	{
		[SerializeField] private Bucket bucket;
		//[SerializeField] private inventory_ui_behavior ui_inventory;
		private inventory_ui ingredient_inventory;
		void Start()
		{
			ingredient_inventory = new inventory_ui();
			ui_inventory.Setinventory(ingredient_inventory);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}