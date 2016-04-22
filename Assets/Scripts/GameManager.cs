using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	private BoardManager boardScript;
	public PlayerManager playerManager = new PlayerManager();

	void Awake()
	{
		MakeSingleton ();
		boardScript = GetComponent<BoardManager> ();
		boardScript.SetupScene ();
	}
}
