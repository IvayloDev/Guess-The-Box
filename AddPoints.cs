using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AddPoints : MonoBehaviour {

	public static Text ScoreText;

	//set all playerPrefs

	public static int Score = 0;
	public static int HighScoreEasy = 0;
	public static int HighScoreHard = 0;
	public static int HighScoreNorm = 0;
	public static int MusicInt = 0;
	


	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();
		Score = 0;
		HighScoreEasy = 0;
		HighScoreNorm = 0;
		HighScoreHard = 0;
		MusicInt = 0;

		//get from playerPrefs
		HighScoreEasy = PlayerPrefs.GetInt("HighScoreEasy", 0 );
		HighScoreNorm = PlayerPrefs.GetInt("HighScoreNorm", 0 );
		HighScoreHard = PlayerPrefs.GetInt("HighScoreHard", 0 );
		MusicInt = PlayerPrefs.GetInt("MusicInt", 0);


		//if authenticated => proceed to report progress
		if(Social.localUser.authenticated){
		if(HighScoreNorm > 10) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreNorm > 20) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreNorm > 50) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreNorm > 100) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreNorm > 200) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreHard > 50) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		
		if(HighScoreEasy > 100) {
			Social.ReportProgress("",100.0f, (bool success) => {
			});
		}
		}
	}



	// Update is called once per frame
	void Update () {

		//set the score text
		ScoreText.text = "" + Score;
		if(BoxController.EndScreenIsActive){
			//is endScreen is active => Disable
			ScoreText.text = "";
			}
		
		if(BoxController.addPoint){
			//if user guessed the right box => add point
			Score++;
			BoxController.addPoint = false;
		}

		


	}



	void OnDestroy(){
		PlayerPrefs.SetInt("HighScoreEasy", HighScoreEasy);
		PlayerPrefs.SetInt("HighScoreHard", HighScoreHard);
		PlayerPrefs.SetInt("HighScoreNorm", HighScoreNorm);
		PlayerPrefs.SetInt("MusicInt", MusicInt);
	}

}
