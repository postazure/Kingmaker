using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public Vector2 Destination { get; set; }
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	private float moveSpeed = 0.01f;
//	private float pickupRange = 0.5f;
//	private Animator animator;

	void Start ()
	{
//		animator = GetComponent<Animator> ();
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		SetDestination ();
		MoveToDestination ();

	}

	void SetDestination ()
	{
		if (Input.GetMouseButton (0)) {
			var mouseClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Destination = mouseClick;

		}
	}

	void MoveToDestination ()
	{
			StartCoroutine(SmoothMovement(Destination));
	}

	IEnumerator SmoothMovement(Vector2 end)
	{
		float sqrRemainingDistance = ((Vector2) transform.position - end).sqrMagnitude;

		while(sqrRemainingDistance > float.Epsilon)
		{
			transform.position = Vector2.MoveTowards (transform.position, Destination, moveSpeed * Time.deltaTime);
			yield return null;
		}
	}
}
