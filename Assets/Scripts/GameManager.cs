using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	private BoardManager boardScript;

	void Awake()
	{
		MakeSingleton ();
		boardScript = GetComponent<BoardManager> ();
		boardScript.SetupScene ();
	}
}
