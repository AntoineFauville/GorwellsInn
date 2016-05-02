using UnityEngine;
using System.Collections;

public class Tavern : MonoBehaviour {

	public GameObject game;
	public GameObject score;
	public GameObject stat;
	public GameObject infos;
	public GameObject indic;

	void OnTriggerEnter(Collider detect)
	{
		if (detect.gameObject.tag == "Player") 
		{
			indic.SetActive (true);

			if (Input.GetButtonDown("AttackDown"))
			{
				if (this.gameObject.name == "Aubergiste") 
				{
					game.SetActive (true);
				} 
				else if (this.gameObject.name == "Score") 
				{
					score.SetActive (true);
				} 
				else if (this.gameObject.name == "Stat") 
				{
					stat.SetActive (true);
				} 
				else if (this.gameObject.name == "LivreD'information") 
				{
					infos.SetActive (true);
				}

				indic.SetActive (false);
			}
			else if (Input.GetButtonDown("AttackRight"))
			{
				if (this.gameObject.name == "Aubergiste") 
				{
					game.SetActive (false);
				} 
				else if (this.gameObject.name == "Score") 
				{
					score.SetActive (false);
				} 
				else if (this.gameObject.name == "Stat") 
				{
					stat.SetActive (false);
				} 
				else if (this.gameObject.name == "LivreD'information") 
				{
					infos.SetActive (false);
				}

				indic.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider detect)
	{
		if (detect.gameObject.tag == "Player") 
		{
			if (Input.GetButtonDown("AttackDown"))
			{
				if (this.gameObject.name == "Aubergiste") 
				{
					game.SetActive (true);
				} 
				else if (this.gameObject.name == "Score") 
				{
					score.SetActive (true);
				} 
				else if (this.gameObject.name == "Stat") 
				{
					stat.SetActive (true);
				} 
				else if (this.gameObject.name == "LivreD'information") 
				{
					infos.SetActive (true);
				}

				indic.SetActive (false);
			}
			else if (Input.GetButtonDown("AttackRight"))
			{
				if (this.gameObject.name == "Aubergiste") 
				{
					game.SetActive (false);
				} 
				else if (this.gameObject.name == "Score") 
				{
					score.SetActive (false);
				} 
				else if (this.gameObject.name == "Stat") 
				{
					stat.SetActive (false);
				} 
				else if (this.gameObject.name == "LivreD'information") 
				{
					infos.SetActive (false);
				}

				indic.SetActive (true);
			}
		}

	}

	void OnTriggerExit(Collider detect)
	{
		if (detect.gameObject.tag == "Player") 
		{
			indic.SetActive (false);

			if (this.gameObject.name == "Aubergiste") 
			{
				game.SetActive (false);
			} 
			else if (this.gameObject.name == "Score") 
			{
				score.SetActive (false);
			} 
			else if (this.gameObject.name == "Stat") 
			{
				stat.SetActive (false);
			} 
			else if (this.gameObject.name == "LivreD'information") 
			{
				infos.SetActive (false);
			}
		}
	}
}
