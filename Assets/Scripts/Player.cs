﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public Vector2 Destination { get; set; }

	public Targetable Target { get; set; }

	public LayerMask blockingLayer;


//	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private Animator animator;

	private float moveSpeed = 5.0f;
	private float meleeRange = 1.5f;

	void Start ()
	{
//		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		GameManager.instance.playerManager.player = this;
	}

	void Update ()
	{
		SetDestination ();

		if (isTargetInRange () && Input.GetMouseButtonDown (0)) {
			if (Target is Resource) {
				animator.SetTrigger ("playerChop");
				((Resource)Target).ApplyDamage (1);
			}
		}
	}

	void FixedUpdate ()
	{
		Move (Destination);
	}

	void SetDestination ()
	{
		if (Input.GetMouseButton (0)) {
			var mouseClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Destination = mouseClick;
		}
	}

	//	void OnCollisionEnter2D(Collision2D coll){

	//	}	
		
	void Move (Vector2 targetPos)
	{
		if ((targetPos - (Vector2)transform.position).sqrMagnitude < 0.5) {
			rb2D.velocity = new Vector2 () * 0;
		} else {
			rb2D.velocity = ((targetPos - (Vector2)transform.position)).normalized * moveSpeed;
		}
	}

	bool isTargetInRange ()
	{
		if (Target == null) {
			return false;
		}
		return (transform.position - Target.transform.position).sqrMagnitude < meleeRange;
	}
}
