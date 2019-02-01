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
            logo.transform.Translate(lengthToPortal - portalLink.transform.up * 1.5f);

            // make logo go in same direction as portal is placed, then rotate logo back to its default rotation to avoid logo flipping issue
            logo.GetComponent<Rigidbody2D>().velocity = logo.GetComponent<Rigidbody2D>().velocity * -transform.up;
            //logo.transform.rotation = Quaternion.Euler(new Vector3());
        }
    }
}
