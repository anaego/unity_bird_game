﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Rigidbody2D rb;
	public float moveSpeed;
	public float flapHeight;
    public GameObject pipe_up;
    public GameObject pipe_down;


    // Use this for initialization
    void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // BuildLevel();
        // rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
		if (Input.GetMouseButtonDown(0)) {
            Jump();
		}
		if (transform.position.y > 18 || transform.position.y < -19) {
			// Death ();
		}
	}

    public void Jump()
    {
        // rb.velocity = new Vector2(rb.velocity.x, flapHeight);
        rb.velocity = Vector2.up * flapHeight;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Dead!");
        rb.bodyType = RigidbodyType2D.Static;
    }

	public void Death() {
		rb.velocity = Vector3.zero;
		transform.position = new Vector2 (0, 0);
        // BuildLevel();
	}

    public void BuildLevel()
    {
        Instantiate(pipe_down, new Vector3(14, 12), transform.rotation);
        Instantiate(pipe_up, new Vector3(14, -11), transform.rotation);

        Instantiate(pipe_down, new Vector3(26, 14), transform.rotation);
        Instantiate(pipe_up, new Vector3(26, -10), transform.rotation);

        Instantiate(pipe_down, new Vector3(38, 10), transform.rotation);
        Instantiate(pipe_up, new Vector3(38, -14), transform.rotation);

        Instantiate(pipe_down, new Vector3(50, 16), transform.rotation);
        Instantiate(pipe_up, new Vector3(50, -8), transform.rotation);

        Instantiate(pipe_down, new Vector3(61, 11), transform.rotation);
        Instantiate(pipe_up, new Vector3(61, -13), transform.rotation);

    }
}
