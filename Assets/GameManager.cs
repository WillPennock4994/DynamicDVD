/*
 * Game Manager contains game loop and helper functions
 * Author: Alex Stevens
 * Date: 1/18/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents a point location
struct Point{
	int x;
	int y;
};

public class GameManager : MonoBehaviour {

	//Attributes
	private int levelNumber;
	private Point cornerLocation;
	private int maxBounces;
	private List<List<GameObject>> levels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Check for collision of ball and walls (check each platform with wall)

		//Check if level ended/level rests/game ended (level ends if corner reached, level resets if max bounces reached, game ends if last level beat)
	}
		
	//Gets the next level and loads to the screen
	void NextLevel(){
		//Check current level and load it
	}
}
