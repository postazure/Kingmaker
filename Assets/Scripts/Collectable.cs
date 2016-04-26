using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
	public string displayName;
	public string systemName;
	public string count;
	public Sprite worldPresence;
	public Sprite inventoryPresence;

	void OnTriggerEnter2D (Collider2D other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		if (player) {
			player.Inventory.Add (this);
			Destroy(this.gameObject);
		}
	}

	public override bool Equals (object o)
	{
		if (!(o is Collectable)) { return false;}

		Collectable other = o as Collectable;
		return this.systemName  == other.systemName;
	}

	public override int GetHashCode ()
	{
		return systemName.GetHashCode();
	}
}