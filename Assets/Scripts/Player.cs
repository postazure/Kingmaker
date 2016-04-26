using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public Targetable Target { get; set; }
	public PlayerManager Manager { get; set; }

	public PlayerInventory Inventory {get; private set;}

	public Vector2 Destination { get; set; }
	public LayerMask blockingLayer;

	//	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private Animator animator;

	private float moveSpeed = 5.0f;
	private float meleeRange = 1.5f;

	void Start ()
	{
		Manager = GameManager.instance.playerManager;
//		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		Manager.Player = this;
		Inventory = Manager.inventory;
	}

	void Update ()
	{
		SetDestination ();
		Move (Destination);
	}

	public bool IsObjectInRange (Vector3 objectsPostion, float addDistance = 0)
	{
		return (transform.position - objectsPostion).sqrMagnitude < meleeRange;
	}

	public void HarvestResource(){
		animator.SetTrigger ("playerChop");
	}

	void SetDestination ()
	{
		if (Input.GetMouseButton (0)) {
			var mouseClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Destination = mouseClick;
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		rb2D.velocity = new Vector2 () * 0;
	}

	void Move (Vector2 targetPos)
	{
		if (IsObjectInRange (targetPos)) {
			rb2D.velocity = new Vector2 () * 0;
		} else {
			rb2D.velocity = ((targetPos - (Vector2)transform.position)).normalized * moveSpeed;
		}
	}		
}
