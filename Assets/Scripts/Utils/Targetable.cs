using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {
	public virtual void OnMouseDown(){
		GameManager.instance.playerManager.SetTarget(this);
	}
}
