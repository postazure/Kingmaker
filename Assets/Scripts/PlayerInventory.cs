using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory
{
	private List<Collectable> contents;

	public PlayerInventory ()
	{
		contents = new List<Collectable> ();
	}

	public void Add (Collectable pickup)
	{
		Collectable itemInInventory = contents.Find (item => item.systemName == pickup.systemName);
		if (itemInInventory) {
			itemInInventory.count += pickup.count;
		} else {
			contents.Add (pickup);
		}
	}

}
