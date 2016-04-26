using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
	private BoardManager boardScript;

	public Text inventoryText;
	public PlayerManager playerManager;

	void Awake()
	{
		MakeSingleton ();

		boardScript = GetComponent<BoardManager> ();
		boardScript.SetupScene ();

		playerManager = new PlayerManager(inventoryText);
	}
}
