using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace GameJam
{

	public class IngredientQueue
	{
		public Ingredient ingredient;
		public Queue<GameObject> fallingIngredientPool;

		public IngredientQueue(Ingredient ingredient, Queue<GameObject> fallingIngredientPool)
		{
			this.ingredient = ingredient;
			this.fallingIngredientPool = fallingIngredientPool;
		}
	}

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

		float spawnrate = 0;
		float spawnTimer = 0;

		Dictionary<Ingredient, IngredientQueue> ingredientPools;

		void Awake()
		{
			alchem = FindObjectOfType<AlchemyManager>();
			IngredientBag = new List<Ingredient>();
			ingredientPools = new Dictionary<Ingredient, IngredientQueue>();
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

			GameObject fallingIngredient;
			if (ingredientPools[ingredient].fallingIngredientPool.Count != 0)
			{
				fallingIngredient = ingredientPools[ingredient].fallingIngredientPool.Dequeue();
				fallingIngredient.transform.position = position;
				fallingIngredient.SetActive(true);
			}
			else
			{
				fallingIngredient = Instantiate(prefab, position, prefab.transform.rotation, transform);
				fallingIngredient.GetComponent<FallingIngredient>().DestroyedCallback.AddListener(PoolFallingIngredient);
			}
		}

		public void PoolFallingIngredient(GameObject fallingIngredient)
		{
			ingredientPools[fallingIngredient.GetComponent<FallingIngredient>().ingredient].fallingIngredientPool.Enqueue(fallingIngredient);
			fallingIngredient.SetActive(false);
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

			foreach (Ingredient ingredient in alchem.AllIngredients)
			{
				ingredientPools.Add(ingredient, new IngredientQueue(ingredient, new Queue<GameObject>()));
			}
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
