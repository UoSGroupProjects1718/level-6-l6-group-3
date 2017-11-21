using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsManager : MonoBehaviour
{

	int wealth = 0;
	int pop = 100;
	int faith = 0;

	public Text PlanetWealthText;
	public Text PopulationText;
	public Text FaithPointsText;


	void Update()
	{
		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "rock") 
		{
			addScore ();
			Destroy (col.gameObject);


		}
	}

	void addScore()
	{
		if (pop >= wealth)
		{
			wealth += 10;
			faith = wealth / 2;
			pop -= 10;
		}

		if (pop <= wealth) 
		{
			return;
		}

	}

}
			
