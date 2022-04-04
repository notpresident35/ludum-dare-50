using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inventory_ui//inventory 
{

	private List<item_ui> itemList;


	public inventory_ui()
	{
		itemList = new List<item_ui>();
		addItem(new item_ui { itemType = item_ui.ItemType.bone, amount = 1 });
		addItem(new item_ui { itemType = item_ui.ItemType.bone, amount = 1 });
		addItem(new item_ui { itemType = item_ui.ItemType.bone, amount = 1 });
		addItem(new item_ui { itemType = item_ui.ItemType.bone, amount = 1 });
		addItem(new item_ui { itemType = item_ui.ItemType.bone, amount = 1 });

		Debug.Log("current: " + itemList);
	}
	public void addItem(item_ui item)
	{
		itemList.Add(item);
	}
	public List<item_ui> GetitemList()
	{
		return itemList;
	}
}
