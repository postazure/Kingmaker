using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public Vector2 Destination { get; set; }


	private float moveSpeed = 3f;
//	private float pickupRange = 0.5f;
//	private Animator animator;

	void Start ()
	{
//		animator = GetComponent<Animator> ();
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
		
		transform.position = Vector2.MoveTowards (transform.position, Destination, moveSpeed * Time.deltaTime);

	}


}
