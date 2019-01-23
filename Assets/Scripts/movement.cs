﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    [SerializeField]
    float velocity;

    [SerializeField]
    Vector3 direction;

    // Use this for initialization
    LineRenderer line;
    Vector3 dir;
    GameObject playArea;

    void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        Debug.Log(Screen.width);
    }
	
	// Update is called once per frame
	void Update () {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        direction = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;

        // Check to see if logo is moving (can't launch while it is moving)
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            if (Input.GetMouseButton(0)) // Left click held down
            {
                Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                dir = (new Vector3(mouse.x, mouse.y, 0) - new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0));
                dir = Vector3.ClampMagnitude(dir, 4);
                line.SetPosition(1, -dir);
            }
            if (Input.GetMouseButtonUp(0)) // Left click lifted up
            {
                line.SetPosition(1, new Vector3(0, 0, 0));
                gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 100);
            }
        }
        CheckWallBounce();
	}

    // check if the logo bounces off the walls of the play area
    void CheckWallBounce(){
        // horizontal collision
        if (gameObject.transform.position.x >= playArea.GetComponent<SpriteRenderer>().bounds.max.x || gameObject.transform.position.x <= playArea.GetComponent<SpriteRenderer>().bounds.min.x){
            // reverse the current velocity in the x direction
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
        // vertical collision
        if (gameObject.transform.position.y >= playArea.GetComponent<SpriteRenderer>().bounds.max.y || gameObject.transform.position.y <= playArea.GetComponent<SpriteRenderer>().bounds.min.y){
            // reverse the current velocity in the y direction
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -gameObject.GetComponent<Rigidbody2D>().velocity.y);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "WallVert")
        {
            Debug.Log("Vert");
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(-1.0f, 1.0f);

            //Slow down every bounce
            //gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(-0.9f, 0.9f);
        }
        else if (coll.gameObject.tag == "WallHorz")
        {
            Debug.Log("Horz");
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(1.0f, -1.0f);

            //Slow down every bounce
            //gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(0.9f, -0.9f);
        }
    }
}
