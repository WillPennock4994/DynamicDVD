/*
 * Manages collision and other operations for walls
 * Author: Alex Stevens
 * Date: 1/18/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
	//Attributes
	public List<GameObject> walls;

	// Use this for initialization
	void Start () {
		//Occupy walls list with first level walls, set as active game objects as well
		walls = new List<GameObject>();
		/*List<GameObject> firstLev = GameObject.Find("GameManager").GetComponent<GameManager>().levels[0];
		for (int i = 0; i < firstLev.Count; i++) {
			firstLev [i].SetActive (true);
			walls.Add (firstLev [i]);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		//Check for collision of logo and walls, do collision
	}

	//Clear walls from list
	public void ClearWalls(){
		//Set removed walls as not active
		for (int i = 0; i < walls.Count; i++) {
			walls [i].SetActive (false);
		}
		walls.Clear ();
	}

	//Add wall to list
	public void AddWalls(GameObject wall){
		//Set added walls as active
		wall.SetActive (true); 
		walls.Add (wall);
	}
}
