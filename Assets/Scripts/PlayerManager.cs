using UnityEngine.UI;

public class PlayerManager
{
	public Player Player{ get; set; }
	public PlayerInventory inventory;

	public PlayerManager(Text inventoryText){
		inventory = new PlayerInventory(inventoryText);
	}

	public void SetTarget (Targetable newTarget)
	{
		Player.Target = newTarget;
	}

}
