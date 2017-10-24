using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityBody : MonoBehaviour {

    public PlanetScript attractorPlanet;
    private Transform playerTransform;

	public bool inGravityField;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "gravityField")
			inGravityField = true;
	}


    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
		if ((attractorPlanet)& inGravityField == true)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
