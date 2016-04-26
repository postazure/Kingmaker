using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory
{
	private List<Collectable> contents;
	private Text inventoryText;

	public PlayerInventory (Text inventoryText)
	{
		contents = new List<Collectable> ();
		this.inventoryText = inventoryText;
	}

	public void Add (Collectable pickup)
	{
		Collectable itemInInventory;
		itemInInventory = contents.Find (item => item.systemName == pickup.systemName) ?? new Collectable ();

		if (itemInInventory.systemName == pickup.systemName) {
			itemInInventory.count += pickup.count;
		} else {
			contents.Add (pickup.Clone ());
		}
	
		updateText ();
	}

	void updateText ()
	{
		string text = "Inventory: \n";

		contents.ForEach(item => {
			text += item.displayName + " x" + item.count;
			text += "\n";
		});

		inventoryText.text = text;
	}
}
