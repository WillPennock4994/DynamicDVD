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

	// Use this for initialization
	void Start () {
		logo = GameObject.Find ("DVDLogo");
		logoStartPosition = logo.transform.position;
        cornerLocation = GameObject.Find("TargetCorner").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Check if level ended/level rests/game ended (level ends if corner reached, level resets if player presses R, game ends if last level beat)
		if (Input.GetKeyDown(KeyCode.R)) {
			ResetLevel ();
		}
        else if (Vector3.Distance (logo.transform.position, cornerLocation) < 1.5f) {
            Debug.Log("Test End");
            SceneManager.LoadScene("YouWin");
        }
	}

	//Resets the level if player pressed restart
	void ResetLevel(){
		//Put logo back at starting point and stop it from moving
		logo.transform.SetPositionAndRotation (logoStartPosition, Quaternion.identity);
		logo.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}
}
