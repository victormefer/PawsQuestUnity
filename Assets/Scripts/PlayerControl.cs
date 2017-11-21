using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float maxRunSpeed = 1.5f;

	private Rigidbody2D rigidBody;
	private Animator anim;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		rigidBody.velocity = new Vector2(move * maxRunSpeed, rigidBody.velocity.y);
		anim.SetFloat("speed", maxRunSpeed * move);

		if ( (move > 0 && !facingRight) || (move < 0 && facingRight) )
			Flip();
	}

	void Flip () {
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
}
