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
	private Vector3 cornerLocation;
	private Vector3 logoStartPosition;
	private GameObject logo;
    private List<string> levels;
    private int currentLevel;
    private List<Color> colors;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
       
		logo = GameObject.Find ("DVDLogo");
        sr = logo.GetComponent<SpriteRenderer>(); //set logo initially to black
        sr.color = new Color(0f, 0f, 0f, 1f);
        colors = new List<Color> { new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 1f, 1f), new Color(0f, 1f, 0f, 1f), new Color(1f, 0f, 0f, 1f),
            new Color(1f, 0f, 1f, 1f), new Color(1f, .92f, 0.016f, 1f), new Color(1f, .64f, 0f, 1f) };

        logoStartPosition = logo.transform.position;
        cornerLocation = GameObject.Find("TargetCorner").transform.position;
        levels = new List<string> { "Level1Tutorial", "Level2", "Level3", "Level4", "Level5", "Level6"}; //set locations and current level
        if (PlayerPrefs.HasKey("currentLevel"))
            currentLevel = PlayerPrefs.GetInt("currentLevel");
        else
            PlayerPrefs.SetInt("currentLevel", 0);
    }
	
	// Update is called once per frame
	void Update () {
		//Check if level ended/level rests/game ended (level ends if corner reached, level resets if player presses R, game ends if last level beat)
		if (Input.GetKeyDown(KeyCode.R)) {
			ResetLevel ();
		}
        else if (Vector3.Distance (logo.transform.position, cornerLocation) < 1.5f) {
            nextLevel();
        }
	}

    // Loads the next level scene
    void nextLevel()
    {
        currentLevel++;
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
        return colors[Random.Range(0, 6)];
    }

	// Resets the level if player pressed restart
	void ResetLevel(){
		//Put logo back at starting point and stop it from moving
		logo.transform.SetPositionAndRotation (logoStartPosition, Quaternion.identity);
		logo.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}
}
