/*
 * Game Manager contains game loop and helper functions
 * Author: Alex Stevens
 * Date: 1/18/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Attributes
	private int levelNumber;
	private Vector3 cornerLocation;
	private Vector3 logoStartPosition;
	private int maxBounces;
	private GameObject logo;
	public List<List<GameObject>> levels;
	public int currentBounces;

	// Use this for initialization
	void Start () {
		maxBounces = 3;
		currentBounces = 0;
		levelNumber = 0;
		logo = GameObject.Find ("DVDLogo");
		logoStartPosition = logo.transform.position;
		cornerLocation.x = 6.5f;
		cornerLocation.y = 4.5f;
		//Set level list by adding wall objects in inspector
	}
	
	// Update is called once per frame
	void Update () {
		//Check if level ended/level rests/game ended (level ends if corner reached, level resets if max bounces reached, game ends if last level beat)
		if (currentBounces == maxBounces) {
			ResetLevel ();
		} else if (Vector3.Distance (logo.transform.position, cornerLocation) < .5f) {
			if (levelNumber + 1 == levels.Count) {
				//swap to end scene
			} else {
				levelNumber++;
				NextLevel ();
			}
		}
	}

	//Resets the level if max bounce was reached
	void ResetLevel(){
		//Put logo back at starting point and stop it from moving, restart current bounces
		logo.transform.SetPositionAndRotation (logoStartPosition, Quaternion.identity);
		logo.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		currentBounces = 0;
	}
		
	//Loads the next level
	void NextLevel(){
		//Update starting position of logo and corner position based on level
		switch (levelNumber) {
			case 1:
				//Set new logo start position and corner position
				break;
			case 2:
				//Set new logo start position and corner position
				break;
		}

		//Get walls from new current level list, add to wall list, and set as active in scene
		GameObject wallM = GameObject.Find ("WallManager");
		wallM.GetComponent<WallManager> ().ClearWalls ();
		for (int i = 0; i < levels [levelNumber].Count; i++) {
			wallM.GetComponent<WallManager> ().AddWalls (levels [levelNumber] [i]);
		}

	}
}
