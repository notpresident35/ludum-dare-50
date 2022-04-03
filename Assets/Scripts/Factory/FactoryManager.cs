using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace GameJam
{
	public class FactoryManager : MonoBehaviour
	{
		List<Ingredient> IngredientBag;

		public AnimationCurve IntensityToSpawnrate;

		public GameObject leftSpawnBorder;
		public GameObject rightSpawnBorder;

		AlchemyManager alchem;

		float spawn_x_min;
		float spawn_x_max;
		float spawn_y;

		public float spawnrate = 0;
		public float spawnTimer = 0;

		void Awake()
		{
			alchem = FindObjectOfType<AlchemyManager>();
			IngredientBag = new List<Ingredient>();
		}

		public void ResetIngredientBag()
		{
			Assert.AreNotEqual(alchem.AllIngredients.Count, 0);

			IngredientBag.Clear();
			foreach (Ingredient ingredient in alchem.AllIngredients)
			{
				for (int i = 0; i < ingredient.Frequency; i++)
				{
					IngredientBag.Add(ingredient);
				}
			}

			IngredientBag.Shuffle();
		}

		public Ingredient GetNextIngredient()
		{
			if (IngredientBag.Count == 0)
			{
				ResetIngredientBag();
			}

			Ingredient ingredient = IngredientBag[IngredientBag.Count - 1];
			IngredientBag.RemoveAt(IngredientBag.Count - 1);
			return ingredient;
		}

		public void SpawnIngredient()
		{
			Ingredient ingredient = GetNextIngredient();
			GameObject prefab = Resources.Load<GameObject>("Prefabs/Ingredients/" + ingredient.name);

			Vector3 position = new Vector3(Random.Range(spawn_x_min, spawn_x_max), spawn_y);

			Instantiate(prefab, position, prefab.transform.rotation, transform);
		}

		public void SetSpawnIntensity(float intensity)
		{
			spawnrate = IntensityToSpawnrate.Evaluate(Mathf.Min(intensity, IntensityToSpawnrate.keys[IntensityToSpawnrate.length - 1].time));
		}

		void Start()
		{
			float left_x = leftSpawnBorder.transform.position.x;
			float right_x = rightSpawnBorder.transform.position.x;
			spawn_x_min = Mathf.Min(left_x, right_x);
			spawn_x_max = Mathf.Max(left_x, right_x);

			float left_y = leftSpawnBorder.transform.position.y;
			float right_y = rightSpawnBorder.transform.position.y;
			spawn_y = (left_y + right_y) / 2;
		}

		void Update()
		{
			spawnTimer += Time.deltaTime * spawnrate;

			if (spawnTimer > 1)
			{
				SpawnIngredient();
				spawnTimer = 0;
			}
		}
	}
}
