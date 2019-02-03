using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //Attributes
    public GameObject portalLink;
    private Vector3 lengthToPortal; // amount to translate to reach other portal
    GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
        logo = GameObject.Find("DVDLogo");
        lengthToPortal = portalLink.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "DVDLogo")
        {
            //translate to the position of the other portal, then place the logo in front of the new portal's up vector (right in front of it)
            logo.transform.Translate(lengthToPortal - portalLink.transform.up);

            // make logo go in same direction as portal is placed, then rotate logo back to its default rotation to avoid logo flipping issue
            // logo.GetComponent<Rigidbody2D>().velocity *= new Vector2(portalLink.transform.up.x, portalLink.transform.up.y);
            //logo.transform.rotation = Quaternion.Euler(new Vector3());
            // Debug.Log(portalLink.tag);

            // if portal is facing up
            if (portalLink.tag == "upPortal") {
                logo.transform.Translate(new Vector3( 0, 1, 0));
                logo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Max(Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.y)));
            }
            // if portal is facing down
            if (portalLink.tag == "downPortal"){
                logo.transform.Translate(new Vector3(0, -1, 0));
                logo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Mathf.Max(Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.y)));
            }
            // if portal is facing right
            if (portalLink.tag == "rightPortal"){
                logo.transform.Translate(new Vector3(1, 0, 0));
                logo.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Max(Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.y)), 0);
            }
            // if portal is facing left
            if (portalLink.tag == "leftPortal"){
                logo.transform.Translate(new Vector3(-1, 0, 0));
                logo.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Max(Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.x), Mathf.Abs(logo.GetComponent<Rigidbody2D>().velocity.y)), 0);
            }
        }
    }
}
