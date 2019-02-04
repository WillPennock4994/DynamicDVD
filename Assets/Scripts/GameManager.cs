/*
 * Game Manager contains game loop and helper functions
 * Author: Alex Stevens
 * Date: 1/18/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Attributes
    private GameObject nice;
	private Vector3 cornerLocation;
	private Vector3 logoStartPosition;
	private GameObject logo;
    private List<string> levels;
    private int currentLevel;
    private int totalBounces;
    private List<Color> colors;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {

        Scene currentScene = SceneManager.GetActiveScene(); //reset playerPrefs if at starting level
        string sceneName = currentScene.name;
        if (sceneName == "Level1Tutorial")
        {
            PlayerPrefs.DeleteAll();
        }

        nice = GameObject.Find("Nice");

        logo = GameObject.Find ("DVDLogo");
        sr = logo.GetComponent<SpriteRenderer>(); //set logo initially to black
        sr.color = new Color(0f, 0f, 0f, 1f);
        colors = new List<Color> { new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 1f, 1f), new Color(0f, 1f, 0f, 1f), new Color(1f, 0f, 0f, 1f),
            new Color(1f, 0f, 1f, 1f), new Color(1f, .92f, 0.016f, 1f), new Color(1f, .64f, 0f, 1f) };

        logoStartPosition = logo.transform.position;
        cornerLocation = GameObject.Find("TargetCorner").transform.position;
        levels = new List<string> { "Level1Tutorial", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10", "Level11", "Level12", "Level13", "Level14" };
        totalBounces = 0;

        if (PlayerPrefs.HasKey("currentLevel"))
            currentLevel = PlayerPrefs.GetInt("currentLevel"); //setup current level in playerprefs
        else
            PlayerPrefs.SetInt("currentLevel", 0);

        if (PlayerPrefs.HasKey("totalBounces"))
            totalBounces = PlayerPrefs.GetInt("totalBounces"); //setup total bounces in playerprefs
        else
            PlayerPrefs.SetInt("totalBounces", 0);
    }
	
	// Update is called once per frame
	void Update () {
		//Check if level ended/level rests/game ended (level ends if corner reached, level resets if player presses R, game ends if last level beat)
		if (Input.GetKeyDown(KeyCode.R)) {
			ResetLevel ();
		}
        //else if (Vector3.Distance (logo.transform.position, cornerLocation) < 1.4f) {
        //   // Invoke("nextLevel", 3.0f);
        //}
        else if (logo.GetComponent<movement>().Win == true)
        {
            Invoke("nextLevel", 4.0f);
            nice.GetComponent<Animator>().SetBool("win", true);
        }
	}

    // Loads the next level scene
    public void nextLevel()
    {
        currentLevel++;
        totalBounces += logo.GetComponent<movement>().getBounces(); //set total bounces
        PlayerPrefs.SetInt("totalBounces", totalBounces);

        if(currentLevel == levels.Count)
        {
            PlayerPrefs.SetInt("currentLevel", 0);
            SceneManager.LoadScene("YouWin");
        }

        else
        {
            PlayerPrefs.SetInt("currentLevel", currentLevel);
            SceneManager.LoadScene(levels[currentLevel]);
        }      
    }

    public Color getRandomColor()
    {
        Color next = colors[Random.Range(0, 6)];
        Color curr = sr.color;
        while((next.r == curr.r) && (next.g == curr.g) && (next.b == curr.b))
        {
            next = colors[Random.Range(0, 6)];
        }
        return next;
    }

	// Resets the level if player pressed restart
	public void ResetLevel(){
		//Put logo back at starting point and stop it from moving
		logo.transform.SetPositionAndRotation (logoStartPosition, Quaternion.identity);
		logo.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
        sr.color = colors[0];
        //logo.GetComponent<movement>().setBounces(0);
        //GameObject.Find("Key").GetComponent<LockKey>().setWallActive();
	}
}
