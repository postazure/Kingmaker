using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T instance = null;

	protected void MakeSingleton()
	{
		if (instance == null) {
			instance = (T)this;
		}
		else if (instance != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}