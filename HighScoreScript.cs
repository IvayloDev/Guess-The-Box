using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class HighScoreScript : MonoBehaviour {

	public GameObject highScore;
	public static Text HighScoreText;

	//yellow color
	public Color yellow = new Color (255.0F,148.0f, 179.0f);


	// Use this for initialization
	void Start () {
		//get text component
		HighScoreText = GetComponent<Text>();
	}

	void Update(){
		// if user gets new highscore => make it yellow
		if(AddPoints.Score >= AddPoints.HighScoreEasy && AddPoints.HighScoreEasy != 0 && ButtonsScript.easyMode){
			HighScoreText.color = yellow;
		}else if(AddPoints.Score >= AddPoints.HighScoreHard && AddPoints.HighScoreHard != 0 && ButtonsScript.hardMode){
			HighScoreText.color = yellow;
		}else if(AddPoints.Score >= AddPoints.HighScoreNorm && AddPoints.HighScoreNorm != 0 && ButtonsScript.normMode){
			HighScoreText.color = yellow;
		}
	}
}
