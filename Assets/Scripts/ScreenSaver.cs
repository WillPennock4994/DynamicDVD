using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSaver : MonoBehaviour
{
    public float velocity;
    public Vector3 direction;

    // Use this for initialization
    LineRenderer line;
    public Vector3 dir;
    GameObject playArea;
    bool set;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        set = true;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        direction = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0) && set)
        {
            dir = Vector3.ClampMagnitude(dir, 4);
            gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * 50);
            set = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer sr = GameObject.Find("DVDLogo").GetComponent<SpriteRenderer>();
        sr.color = GameObject.Find("GameManager").GetComponent<GameManager>().getRandomColor();
    }
}
