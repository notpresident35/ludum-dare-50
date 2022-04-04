using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameJam
{
	public class inventory_ui//inventory 
	{
		[SerializeField] Bucket bucket;
		List<Sprite> test;

		private void Awake()
		{
			bucket.stateChanged.AddListener(ExperimentDeleteLater);
		}
		public void ExperimentDeleteLater()
		{
			for (int i = 0; i < bucket.contents.Count; i++)
			{
				test.Add(bucket.contents[i].Icon);
			}
		}
		public List<Sprite> Getitem()
		{
			return test;
		}
	}
}
