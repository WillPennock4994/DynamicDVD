using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    bool win = false;
    public bool Win
    {
        get { return win; }
    }

    float velocity;
    Vector3 direction;

    int bounceNum = 0;
    Text bounceText;

    // Use this for initialization
    LineRenderer line;
    Vector3 dir;
    GameObject playArea;

    void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
       // bounceText = GameObject.Find("Bounces").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        direction = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;

       // bounceText.text = "Bounces: " + bounceNum;

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
        // CheckWallBounce();
    }

    //Get the current bounces
    public int getBounces()
    {
        return bounceNum;
    }

    //Set the current bounces
    public void setBounces(int bounces)
    {
        bounceNum = bounces;
    }

    /*
    // check if the logo bounces off the walls of the play area
    void CheckWallBounce(){
        // horizontal collision
        if (gameObject.transform.position.x >= playArea.GetComponent<SpriteRenderer>().bounds.max.x){
            // reverse the current velocity in the x direction
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(-1.0f, 1.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
        else if (gameObject.transform.position.x <= playArea.GetComponent<SpriteRenderer>().bounds.min.x) {
            // reverse the current velocity in the x direction
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(-1.0f, 1.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
        // vertical collision
        if (gameObject.transform.position.y >= playArea.GetComponent<SpriteRenderer>().bounds.max.y){
            // reverse the current velocity in the y direction
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(1.0f, -1.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
        else if (gameObject.transform.position.y <= playArea.GetComponent<SpriteRenderer>().bounds.min.y) {
            // reverse the current velocity in the y direction
            gameObject.GetComponent<Rigidbody2D>().velocity *= new Vector2(1.0f, -1.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z);
            GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().currentBounces++;
        }
	}
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        bounceNum += 1;
        SpriteRenderer sr = GameObject.Find("DVDLogo").GetComponent<SpriteRenderer>();
        sr.color = GameObject.Find("GameManager").GetComponent<GameManager>().getRandomColor();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Goal")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            win = true;
        }
    }
}
