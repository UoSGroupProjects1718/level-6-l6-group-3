using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsManager : MonoBehaviour
{

	public int wealth = 0;
	public int pop = 0;
	public int faith = 0;

	public Text PlanetWealthText;
	public Text PopulationText;
	public Text FaithPointsText;

	public Text debugPlanetLevel;

	public int planetLevel = 0;

	public GameObject planet;

	public GameObject gravityField;

	public GameObject terraPlanet;

	public ParticleSystem planetSmoke;

	public Renderer terraRend;

	public SphereCollider terraSphere;

	public SphereCollider gravityFieldSize;

	public bool terraPlanetLive;

	void Start ()
	{
		terraRend = terraPlanet.GetComponent<Renderer> ();

		//colRadius = planetCol.GetComponent<SphereCollider> ();

		gravityFieldSize = gravityField.GetComponent<SphereCollider> ();

		terraSphere = terraPlanet.GetComponent<SphereCollider> ();

		terraSphere.enabled = false;

	}



	void Update()
	{
		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

		debugPlanetLevel.text = planetLevel.ToString ();

		planet.transform.Rotate (0, Time.deltaTime*5, Time.deltaTime*10);

		if (planetLevel == 13) 
		{
			changePlanetType ();
			terraPlanetLive = true;
		}

		if (terraPlanetLive == true) 
		{
			addPop ();
		}

		if (planetLevel % 5 == 0 && planetLevel>=5 && terraPlanetLive == false) 
		{
			planetLevel += 1;
			changePlanetSize ();
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "rock") 
		{
			planetLevel += 1;
			addScore ();
			Destroy (col.gameObject);


			//col.gameObject.transform.position = new Vector3 (1400, 450, -136);
			//col.gameObject.GetComponent<PlayerGravityBody> ().inGravityField = false;
			//col.gameObject.GetComponent<asteroidPath> ().onPath = true;
			//col.gameObject.GetComponent<asteroidStats>().statsAdded = false;
			//col.gameObject.GetComponent<Renderer>().material.color = Color.gray;

			//ParticleSystem.EmissionModule em = gameObject.GetComponentInChildren<ParticleSystem>().emission;
			//em.enabled = false;




		}
	}


	void changePlanetSize()
	{
		gravityField.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planet.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
		planetSmoke.Play ();
	}


	void changePlanetType()
	{
		terraRend.enabled = true;

		terraSphere.enabled = true;
		gravityFieldSize.radius = 480;



	}

	void addPop()
	{
		pop = 1000;
	}

	void addScore()
	{
		if (planetLevel >= 10)
		{
			wealth += 10;
			faith = wealth / 2;
			pop -= 10;

			addPop ();


		}

		if (pop <= 0) 
		{
			pop = 0;
		}

		if (pop >= wealth) 
		{
			addFaith();
		}


	}

	void addFaith()
	{
		faith = pop/5 + wealth / 2;
	}

}
			
