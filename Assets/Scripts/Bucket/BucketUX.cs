using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketUX : MonoBehaviour
{
	public GameJam.Bucket AttachedBucket;

	public List<SpriteRenderer> ingredientIcons;
	public SpriteRenderer monsterIcon;
	GameJam.AlchemyManager alchem;

	public void BindBucket(GameJam.Bucket bucket)
	{
		AttachedBucket = bucket;
	}

	public void Spawn()
	{
		AttachedBucket.stateChanged.AddListener(UpdateUX);
		/*monsterIcon = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
		for (int i = 1; i < transform.GetChild(0).childCount; i++)
		{
			ingredientIcons.Add(transform.GetChild(0).GetChild(i).GetComponent<SpriteRenderer>());
		}*/
		alchem = FindObjectOfType<GameJam.AlchemyManager>();
	}

	void UpdateUX()
	{
		for (int i = 0; i < ingredientIcons.Count; i++)
		{
			if (i < AttachedBucket.contents.Count)
			{
				ingredientIcons[i].sprite = AttachedBucket.contents[i].Icon;
			}
			else
			{
				ingredientIcons[i].sprite = null;
			}
		}

		monsterIcon.sprite = alchem.GetMonster(AttachedBucket.contents)?.sprite;
	}

	void Update()
	{
		transform.position = AttachedBucket.transform.position;

		if (transform.position.x < -1f)
		{
			transform.localScale = new Vector3(1, 1, 1);
			for (int i = 0; i < ingredientIcons.Count; i++)
			{
				ingredientIcons[i].flipX = false;
			}
			monsterIcon.flipX = false;
		}
		else if (transform.position.x > 2f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
			for (int i = 0; i < ingredientIcons.Count; i++)
			{
				ingredientIcons[i].flipX = true;
			}
			monsterIcon.flipX = true;
		}
	}
}
