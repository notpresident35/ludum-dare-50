using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
	public class PlayerAvatar : MonoBehaviour
	{
		// =========================================================
		// Variables
		// =========================================================

		public PlayerAvatarConfig config;

		[SerializeField] private PlayerAvatarState _state;
		public ManualTimer inputThrowBuffer = new ManualTimer(0.1f);

		public bool debugLog;

		public Vector2 curVel;

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
					Debug.Log($"[PlayerAvatar] {_state} => {value}");
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
			inputThrowBuffer.Stop();
		}

		// =========================================================
		// Update Loop
		// =========================================================

		private void Update()
		{
			inputThrowBuffer.Update(Time.deltaTime);

			if (Input.GetButtonDown("Fire1"))
			{
				inputThrowBuffer.Start();
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

			if (inputThrowBuffer.Running)
			{
				inputThrowBuffer.Stop();
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