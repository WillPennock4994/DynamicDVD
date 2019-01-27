using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockKey : MonoBehaviour
{
    public GameObject lockedWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(lockedWall != null && coll.gameObject.name == "DVDLogo")
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            Destroy(lockedWall);
        }
    }
}
