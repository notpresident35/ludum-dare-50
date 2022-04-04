using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameJam
{
	public class PlayerAvatar : MonoBehaviour
	{
		// =========================================================
		// Variables
		// =========================================================

		private const float BufferDuration = 0.1f;

		public PlayerAvatarConfig config;
		public bool debugLog;

		public ManualTimer inputUseBuffer = new ManualTimer(BufferDuration);
		public ManualTimer inputAssembleBuffer = new ManualTimer(BufferDuration);

		[SerializeField] private PlayerAvatarState _state;
		public Vector2 curVel;
		public Bucket heldBucket;

		public CircleCollider2D interactArea;
		public LayerMask interactMask;

		private Rigidbody2D body;
		private SpriteRenderer spriteRen;
		private Animator anim;

		// =========================================================
		// Properties
		// =========================================================

		public PlayerAvatarState State
		{
			get => _state;
			set
			{
				if (debugLog)
				{
					Debug.Log($"[PlayerAvatar] {_state} -> {value}");
				}
				_state = value;
			}
		}

		// =========================================================
		// Initialization
		// =========================================================

		private void Awake()
		{
			body = GetComponent<Rigidbody2D>();
			spriteRen = GetComponent<SpriteRenderer>();
			anim = GetComponent<Animator>();
		}

		private void Start()
		{
			_state = PlayerAvatarState.Hold;
			State = PlayerAvatarState.Walk;
			curVel = Vector2.zero;
			inputUseBuffer.Stop();
		}

		// =========================================================
		// Update Loop
		// =========================================================

		private void Update()
		{
			inputUseBuffer.Update(Time.deltaTime);
			inputAssembleBuffer.Update(Time.deltaTime);

			if (Input.GetButtonDown("Fire1"))
			{
				inputUseBuffer.Start();
			}

			if (Input.GetButtonDown("Fire2"))
			{
				inputAssembleBuffer.Start();
			}

			if (debugLog && UXHelper.TargetInteractable != null)
			{
				Debug.DrawRay(UXHelper.TargetInteractable.transform.position, Vector3.up, Color.white);
				Debug.Log($"[PlayerAvatar] Target: {UXHelper.TargetInteractable.name}");
			}
		}

		private void FixedUpdate()
		{
			UpdateTargetObject();

			switch (State)
			{
				case PlayerAvatarState.Walk: StateWalk(); break;
				case PlayerAvatarState.Hold: StateUse(); break;

				default:
					State = PlayerAvatarState.Walk;
					break;
			}
		}

		// =========================================================
		// States
		// =========================================================

		private void StateWalk()
		{
			WalkStandard();

			if (inputUseBuffer.Running && UXHelper.TargetInteractable != null)
			{
				inputUseBuffer.Stop();
				StateUseEnter();
				State = PlayerAvatarState.Hold;
			}
		}

		private void StateUseEnter()
		{
			heldBucket = UXHelper.TargetInteractable.GetComponent<Bucket>();
			UXHelper.TargetInteractable = null;
			heldBucket.PickUp();
			Debug.Log("Pickup " + heldBucket.name);
			anim.SetBool("BucketHeld", true);
		}

		private void StateUse()
		{
			WalkStandard();

			if (inputAssembleBuffer.Running)
			{
				inputAssembleBuffer.Stop();
				Assemble();
			}

			if (inputUseBuffer.Running)
			{
				inputUseBuffer.Stop();
				heldBucket.Throw();
				heldBucket = null;
				State = PlayerAvatarState.Walk;
				anim.SetBool("BucketHeld", false);
			}
		}

		// =========================================================
		// Common
		// =========================================================

		private void WalkStandard()
		{
			float horz = Input.GetAxisRaw("Horizontal");

			curVel = body.velocity;

			curVel.x = Mathf.MoveTowards(
				curVel.x,
				horz * config.walkHorzMax,
				config.walkHorzAccel * Time.fixedDeltaTime);

			body.velocity = curVel;

			if (horz != 0)
			{
				spriteRen.flipX = horz < 0;
			}
			anim.SetFloat("MovementSpeed", horz);
		}

		private void Assemble()
		{
			var ingredients = new List<Ingredient>(heldBucket.contents);
			heldBucket.ClearContents();

			Debug.Log("Contents: " + string.Join(", ", ingredients));
			// TODO: If null, fancy stuff (recipe fizzles)
			var monster = FindObjectOfType<AlchemyManager>().GetMonster(ingredients);
			FindObjectOfType<CampaignManager>().SpawnMonster(heldBucket.trackId, monster);

			Instantiate(config.assembleEffects, transform.position, transform.rotation);
		}

		// =========================================================
		// Interactions
		// =========================================================

		private struct TargetSort
		{
			public GameObject obj;
			public float height;
			public float dx;
		}

		private void UpdateTargetObject()
		{
			if (State == PlayerAvatarState.Hold)
			{
				UXHelper.TargetInteractable = null;
				return;
			}

			Vector2 circleCenter = (Vector2)interactArea.transform.position + interactArea.offset;
			var list = Physics2D.OverlapCircleAll(circleCenter, interactArea.radius, interactMask)
				.Where(x => x.GetComponent<Bucket>() != null);

			GameObject target = null;
			if (list.Any())
			{
				var sortY = list
					.Select(x => new TargetSort()
					{
						obj = x.gameObject,
						height = x.transform.position.y,
						dx = Mathf.Abs(circleCenter.x - x.transform.position.x)
					})
					.OrderBy(x => x.height);

				float minHeight = sortY.First().height;

				target = sortY
					.Where(x => Mathf.Abs(minHeight - x.height) < config.sameYTolerance)
					.OrderBy(x => x.dx)
					.First().obj;

				// i want to die
			}
			UXHelper.TargetInteractable = target;
		}
	}
}
