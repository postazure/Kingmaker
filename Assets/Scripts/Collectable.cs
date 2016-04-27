using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
	public string displayName;
	public string systemName;
	public int count;
	public Sprite worldPresence;
	public Sprite inventoryPresence;

	void Start(){
		this.count = 1;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Player player = other.gameObject.GetComponent<Player> ();
		if (player) {
			player.Inventory.Add (this);
			Destroy(this.gameObject);
		}
	}

	public override string ToString ()
	{
		return systemName;
	}
	
}