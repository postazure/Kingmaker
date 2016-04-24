using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour
{
	public virtual void OnMouseDown ()
	{
		GameManager.instance.playerManager.SetTarget (this);
	}

	public virtual void RemoveTarget ()
	{
		GameManager.instance.playerManager.SetTarget (null);
	}

	protected void OnDisable ()
	{
		RemoveTarget ();
	}
}
