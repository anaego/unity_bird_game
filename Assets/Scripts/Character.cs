using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Rigidbody2D rb;
	public float moveSpeed;
	public float flapHeight;
    public GameObject pipe_up;
    public GameObject pipe_down;
    private static Character instance;
    private State state;
    public event EventHandler OnDied;
    public event EventHandler OnStartPlaying;

    private enum State
    {
        WaitingToStart,
        Playing,
        Dead,
    }

    public static Character GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        instance = this;
        rb.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            default:
            case State.WaitingToStart:
                if (Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    OnStartPlaying?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
                break;
            case State.Dead:
                break;
        }
	}

    public void Jump()
    {
        rb.velocity = Vector2.up * flapHeight;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        rb.bodyType = RigidbodyType2D.Static;
        OnDied?.Invoke(this, EventArgs.Empty);
    }

	public void Death() {
		rb.velocity = Vector3.zero;
		transform.position = new Vector2 (0, 0);
	}
}
