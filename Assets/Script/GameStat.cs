using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStat : MonoBehaviour {

	public Text DeathCount;
	public Text VictoryCount;
	public Text EnnemyCount;
	public Text TimeDungeon;

	void Start () 
	{
		int nbreDeath = PlayerPrefs.GetInt ("Death");
		int nbreVictory = PlayerPrefs.GetInt ("Victory");
		int nbreEnnemy = PlayerPrefs.GetInt ("Ennemy");
		float DungeonTime = PlayerPrefs.GetFloat ("DungeonTime");
		System.TimeSpan timeDisplay = System.TimeSpan.FromSeconds(DungeonTime);

		DeathCount.text = nbreDeath.ToString ();
		VictoryCount.text = nbreVictory.ToString ();
		EnnemyCount.text = nbreEnnemy.ToString ();
		TimeDungeon.text = string.Format (/*"{0}:{01:00}"*/ "{0:D2}:{1:D2}:{2:D2}:{3:D2}" , timeDisplay.Days, timeDisplay.Hours, timeDisplay.Minutes, timeDisplay.Seconds);
	}
		
}
