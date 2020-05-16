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
        // BuildLevel();
        // rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        switch (state)
        {
            default:
            case State.WaitingToStart:
                if (Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    if (OnStartPlaying != null) OnStartPlaying(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
                if (transform.position.y > 18 || transform.position.y < -19)
                {
                    // Death ();
                }
                break;
            case State.Dead:
                break;
        }
	}

    public void Jump()
    {
        // rb.velocity = new Vector2(rb.velocity.x, flapHeight);
        rb.velocity = Vector2.up * flapHeight;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        rb.bodyType = RigidbodyType2D.Static;
        if (OnDied != null) OnDied(this, EventArgs.Empty);
    }

	public void Death() {
		rb.velocity = Vector3.zero;
		transform.position = new Vector2 (0, 0);
        // BuildLevel();
	}

    //public void BuildLevel()
    //{
    //    Instantiate(pipe_down, new Vector3(14, 12), transform.rotation);
    //    Instantiate(pipe_up, new Vector3(14, -11), transform.rotation);

    //    Instantiate(pipe_down, new Vector3(26, 14), transform.rotation);
    //    Instantiate(pipe_up, new Vector3(26, -10), transform.rotation);

    //    Instantiate(pipe_down, new Vector3(38, 10), transform.rotation);
    //    Instantiate(pipe_up, new Vector3(38, -14), transform.rotation);

    //    Instantiate(pipe_down, new Vector3(50, 16), transform.rotation);
    //    Instantiate(pipe_up, new Vector3(50, -8), transform.rotation);

    //    Instantiate(pipe_down, new Vector3(61, 11), transform.rotation);
    //    Instantiate(pipe_up, new Vector3(61, -13), transform.rotation);

    //}
}
