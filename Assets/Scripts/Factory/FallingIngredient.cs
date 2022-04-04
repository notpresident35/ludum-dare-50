using UnityEngine;
using UnityEngine.Events;

public class FallingIngredient : MonoBehaviour
{
	public UnityEvent<GameObject> DestroyedCallback;
	public Ingredient ingredient;
	public GameObject destroyEffects;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = ingredient.GravityModifier;
	}

	/// <summary>
	/// Called when ingredient lands in bucket.
	/// </summary>
	public void Collect()
	{
		DestroyedCallback?.Invoke(gameObject);
		// Skips the object pool for objects manually placed into the scene
#if UNITY_EDITOR
		if (gameObject.activeSelf)
		{
			Destroy(gameObject);
		}
#endif
	}

	/// <summary>
	/// Called when ingredient falls out of world.
	/// </summary>
	public void Delete()
	{
		Instantiate(destroyEffects, transform.position, transform.rotation);

		DestroyedCallback?.Invoke(gameObject);
		// Skips the object pool for objects manually placed into the scene
#if UNITY_EDITOR
		if (gameObject.activeSelf)
		{
			Destroy(gameObject);
		}
#endif
	}

	void Update()
	{
		rb.angularVelocity = Random.Range(-10f, 10f);
	}
}
