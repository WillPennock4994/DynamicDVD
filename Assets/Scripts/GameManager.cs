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
    private List<string> logos;

	// Use this for initialization
	void Start () {
		logo = GameObject.Find ("DVDLogo");
        logos = new List<string> { "DVDLogoBlack", "DVDLogoRed", "DVDLogoBlue", "DVDLogoOrange", "DVDLogoPurple" };
        logoStartPosition = logo.transform.position;
        cornerLocation = GameObject.Find("TargetCorner").transform.position;
        levels = new List<string> { "Level1Tutorial", "Level2", "Level3", "Level4", "Level5", "Level6"};
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

	// Resets the level if player pressed restart
	void ResetLevel(){
		//Put logo back at starting point and stop it from moving
		logo.transform.SetPositionAndRotation (logoStartPosition, Quaternion.identity);
		logo.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}
}
