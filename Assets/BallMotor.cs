﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotor : MonoBehaviour 
{

	private Rigidbody2D rb2d;
	private Vector2 vel;

	//ball mover
	void GoBall ()
	{
		float rand = Random.Range(0, 2);
		if(rand < 1)
		{
			rb2d.AddForce(new Vector2(20, -15));
		} 
		else 
		{
			rb2d.AddForce(new Vector2(-20, -15));
		}
	}

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("GoBall", 2);						//2 second wait time
	}

	//resets ball position
	void ResetBall ()
	{
		vel = Vector2.zero;
		rb2d.velocity = vel;
		transform.position = Vector2.zero;
	}

	//restarts game
	void RestartGame ()
	{
		ResetBall();
		Invoke("GoBall", 1);
	}

	//collider
	void OnCollisionEnter2D (Collision2D coll) 
	{
		if (coll.collider.CompareTag("Player"))
		{
			vel.x = rb2d.velocity.x;
			vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
			rb2d.velocity = vel;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
