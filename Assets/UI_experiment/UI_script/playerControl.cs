using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

	[SerializeField] Rigidbody2D player;

	private float horizontalAxis;

	void Start()
	{
		player = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{
		horizontalAxis = Input.GetAxisRaw("Horizontal");
		player.velocity = new Vector2(horizontalAxis * 5f, player.velocity.y);
	}
}
