using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{

	public GameObject UI;
	float timer = 0;

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			timer += Time.deltaTime;
			UI.SetActive(true);
		}
		else
		{
			timer = 0;
			UI.SetActive(false);
		}

		if (timer > 3)
		{
			Application.Quit();
		}
	}
}
