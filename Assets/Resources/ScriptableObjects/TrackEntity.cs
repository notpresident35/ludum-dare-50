using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackEntity : ScriptableObject
{

	public float Health;
	public float Damage;
	public float AttackDelay;
	public float KillMovementDelay;
	public float Size;
	public float Speed;
	public Sprite sprite;
	public LayerMask AttackMask;
	public LayerMask FriendlyMask;
	public AudioClip[] AttackSFX;
	public AudioClip DeathSFX;
}