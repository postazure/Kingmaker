
public class PlayerManager
{
	public Player Player{ get; set; }
	public PlayerInventory inventory = new PlayerInventory();

	public void SetTarget (Targetable newTarget)
	{
		Player.Target = newTarget;
	}

}
