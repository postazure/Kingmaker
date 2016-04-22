using UnityEngine;
using System.Collections;

public class Resource : Targetable
{
//	public AudioClip chopSound1;
	//1 of 2 audio clips that play when the wall is attacked by the player.
//	public AudioClip chopSound2;
	//2 of 2 audio clips that play when the wall is attacked by the player.
	//Alternate sprite to display after Wall has been attacked by player.
	public Sprite[] sprites;

	private int hp;
	private int damageTaken = 0;
	private SpriteRenderer spriteRenderer;

	void Awake ()
	{
		hp = sprites.Length;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites[damageTaken];
	}
		

	//DamageWall is called when the player attacks a wall.
	public void ApplyDamage (int damageDealt)
	{
		//Call the RandomizeSfx function of SoundManager to play one of two chop sounds.
//		SoundManager.instance.RandomizeSfx (chopSound1, chopSound2);

		damageTaken += damageDealt;

		if (damageTaken >= hp) {
			gameObject.SetActive (false);
			RemoveTarget ();
		} else {
			spriteRenderer.sprite = sprites[damageTaken];
		}
	}
}

