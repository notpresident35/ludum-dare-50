using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
	public enum State
	{
		Menu,
		MainGame,
		GameOver,
		Credits
	}

	public static State state;

	public static bool Paused = false;
}
