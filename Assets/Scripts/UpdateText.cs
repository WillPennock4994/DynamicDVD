using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("totalBounces"))
            score = PlayerPrefs.GetInt("totalBounces"); //setup total bounces in playerprefs
        else
            PlayerPrefs.SetInt("totalBounces", 0);

        GameObject t = GameObject.Find("MainText");
        t.GetComponent<Text>().text = "You beat the game with " + score + " bounces!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
