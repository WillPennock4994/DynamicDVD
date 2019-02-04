﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSaver : MonoBehaviour
{
    public float velocity;
    public Vector3 direction;

    int bounceNum = 0;
    Text bounceText;

    // Use this for initialization
    LineRenderer line;
    public Vector3 dir;
    GameObject playArea;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        // bounceText = GameObject.Find("Bounces").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        direction = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            dir = Vector3.ClampMagnitude(dir, 4);
            gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 100);
        }
        // bounceText.text = "Bounces: " + bounceNum;
        /*
        // Check to see if logo is moving (can't launch while it is moving)
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
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
        */
        // CheckWallBounce();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bounceNum += 1;
        SpriteRenderer sr = GameObject.Find("DVDLogo").GetComponent<SpriteRenderer>();
        sr.color = GameObject.Find("GameManager").GetComponent<GameManager>().getRandomColor();
    }
}
