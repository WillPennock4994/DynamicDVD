using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockKey : MonoBehaviour
{
    public GameObject lockedWall;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create new wall
    public void setWallActive()
    {
        lockedWall.SetActive(true);
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(lockedWall != null && coll.gameObject.name == "DVDLogo")
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            lockedWall.SetActive(false);
        }
    }
}
