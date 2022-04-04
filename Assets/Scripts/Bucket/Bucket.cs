using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameJam
{
	public class Bucket : MonoBehaviour
	{
		public const int MaxItems = 4;

		/// <summary>
		/// The associated track number. -1 if invalid.
		/// </summary>
		public int trackId = -1;

		/// <summary>
		/// The ingredients in the bucket. Readonly.
		/// </summary>
		public List<Ingredient> contents;

		/// <summary>
		/// True if bucket is held by player.
		/// </summary>
		public bool isHeld;

		/// <summary>
		/// Upward velocity on releasing the bucket.
		/// </summary>
		public float throwVel = 8;

		/// <summary>
		/// Raised when the logical of the bucket changes.
		/// </summary>
		public UnityEvent stateChanged;

		[Header("SFX")]
		public AudioClip PickupSFX;
		public AudioClip ThrowSFX;
		public AudioClip GetIngredientSFX;


		private Rigidbody2D body;

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			contents = new List<Ingredient>(MaxItems);
		}

		public void Configure(int trackId)
		{
			this.trackId = trackId;
			stateChanged.Invoke();
		}

		public void PickUp()
		{
			isHeld = true;
			AudioManager.Instance.PlaySoundEffect(PickupSFX);
			stateChanged.Invoke();
		}

		public void Throw()
		{
			body.velocity = new Vector2(0, throwVel);
			isHeld = false;
			AudioManager.Instance.PlaySoundEffect(ThrowSFX);
			stateChanged.Invoke();
		}

		public void ClearContents()
		{
			contents.Clear();
			stateChanged.Invoke();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var fallObj = collision.GetComponent<FallingIngredient>();
			if (fallObj != null && contents.Count < MaxItems)
			{
				contents.Add(fallObj.ingredient);
				AudioManager.Instance.PlaySoundEffect(GetIngredientSFX);
				stateChanged.Invoke();

				fallObj.Collect();
			}
		}
	}
}