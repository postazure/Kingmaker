﻿using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	void Awake()
	{
		MakeSingleton ();
	}
}
