using UnityEngine;
using System.Collections;

public class Resource : Targetable
{
	public Sprite[] sprites;
	public GameObject itemDrop;

	private int hp;
	private int damageTaken = 0;
	private SpriteRenderer spriteRenderer;

	void Awake ()
	{
		hp = sprites.Length;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [damageTaken];
	}

	public void Harvest (int damageDealt)
	{

		damageTaken += damageDealt;

		if (damageTaken >= hp) {
			gameObject.SetActive (false);
		} else {
			spriteRenderer.sprite = sprites [damageTaken];
		}
	}

	public override void OnMouseDown ()
	{
		var player = GameManager.instance.playerManager.Player;

		if (player.IsObjectInRange (this.transform.position)) {
			player.HarvestResource ();
			this.Harvest (1);
		}
	
		base.OnMouseDown ();
	}

	void OnDisable ()
	{
		Instantiate (itemDrop, transform.position, transform.rotation);
	}
}

