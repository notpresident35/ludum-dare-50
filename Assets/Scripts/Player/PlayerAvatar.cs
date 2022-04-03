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
		public GameObject heldObject;

		private Rigidbody2D body;
		private SpriteRenderer spriteRen;

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
		}

		private void Start()
		{
			_state = PlayerAvatarState.Throw;
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
		}

		private void FixedUpdate()
		{
			switch (State)
			{
				case PlayerAvatarState.Walk: StateWalk(); break;
				case PlayerAvatarState.Throw: StateThrow(); break;

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

			if (inputUseBuffer.Running)
			{
				inputUseBuffer.Stop();
				State = PlayerAvatarState.Throw;
			}
		}

		private void StateThrow()
		{
			Debug.Log("yeet");
			State = PlayerAvatarState.Walk;
		}
	}
}