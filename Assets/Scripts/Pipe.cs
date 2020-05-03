using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	private Character character;
    public GameObject pipeDown;

	// Use this for initialization
	void Start () {
		character = FindObjectOfType<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		if (character.transform.position.x - transform.position.x > 30) {
            float xRan = Random.Range(0, 10);
            float yRan = Random.Range(-5, 5);
            float gapRan = Random.Range(0, 3);

            Instantiate(gameObject, new Vector2(character.transform.position.x + 15 + xRan, -11 + yRan), transform.rotation);
            Instantiate(pipeDown, new Vector2(character.transform.position.x + 15 + xRan, 12 + yRan), transform.rotation);
            Destroy(gameObject);
        }
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			character.Death ();
		}
	}
}
