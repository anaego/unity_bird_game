using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeD : MonoBehaviour
{

    private Character character;

    void Start()
    {
        character = FindObjectOfType<Character>();
    }

    void Update()
    {
        if (character.transform.position.x - transform.position.x > 30)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            character.Death();
        }

    }

}
