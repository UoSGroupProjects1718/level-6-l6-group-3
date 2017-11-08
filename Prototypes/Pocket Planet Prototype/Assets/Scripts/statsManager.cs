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

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "rock")
		{
			wealth+=10;
			faith = wealth / 2;
			pop -= 1;
			col.gameObject.GetComponent<Renderer>().material.color = Color.red;
			//col.gameObject.transform.localScale += new Vector3(-0.001F, -0.001F, -0.001F);
		}
	}

	void Update()
	{
		PlanetWealthText.text = wealth.ToString();
		PopulationText.text = pop.ToString ();
		FaithPointsText.text = faith.ToString ();

	}

}