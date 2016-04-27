using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory
{
	private List<InventoryItem> contents;
	private Text inventoryText;

	public PlayerInventory (Text inventoryText)
	{
		contents = new List<InventoryItem> ();
		this.inventoryText = inventoryText;
	}

	public void Add (Collectable pickup)
	{
		InventoryItem pickupItem = new InventoryItem (pickup);
		InventoryItem itemInInventory;
		itemInInventory = contents.Find (item => item.Equals(pickupItem));

		if (itemInInventory == null) {
			contents.Add (pickupItem);
		} else {
			itemInInventory.count += pickupItem.count;
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



	class InventoryItem {
		//InventoryItem is needed to strip the MonoBehavior from the Collectable class
		//otherwise there is wierd interaction with 'null'
		public string displayName;
		public string systemName;
		public int count;
		public Sprite worldPresence;
		public Sprite inventoryPresence;

		public InventoryItem(Collectable collectable){
			this.displayName = collectable.displayName;
			this.systemName = collectable.systemName;
			this.count = collectable.count;
			this.worldPresence = collectable.worldPresence;
			this.inventoryPresence = collectable.inventoryPresence;
		}

		public override bool Equals (object obj)
		{
			if (!(obj is InventoryItem)) {
				return false;
			}
			return systemName == (obj as InventoryItem).systemName;
		}
	}
}
