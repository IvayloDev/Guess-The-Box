using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour {
	public GameObject playButt;
	public GameObject modes;
	public GameObject musicButt;
	public GameObject Pause;
	public GameObject PauseMenu;
	public static bool easyMode = false;
	public static bool hardMode = false;
	public static bool normMode = false;
	public GameObject audioListener;
	public Sprite MusicOnSprite;
	public Sprite MusicOffSprite;


	//handling button presses

	public void onRestartClick(){
		Application.LoadLevel(Application.loadedLevel);
		BoxController.EnableBoxClicks = false;
	}

	public void onMenuClick(){
		Application.LoadLevel("StartScreen");
	}

	public void onMenuPauseClick(){
		Application.LoadLevel("StartScreen");
		BoxController.EnableBoxClicks = false;
	}

	public void onPlayClick(){
		playButt.SetActive(false);
		modes.SetActive(true);
	}

	public void onPauseClick(){
		//pause timer.
		BoxController.EnableBoxClicks = true;
		PauseMenu.SetActive(true);
		Pause.SetActive(false);
	}

	public void onResumeClick(){
		PauseMenu.SetActive(false);
		Pause.SetActive(true);
		BoxController.EnableBoxClicks = false;
	}
	
	public void onEasyClick(){
		Application.LoadLevel("GameScreen");
		hardMode = false;
		normMode = false;
		easyMode = true;
	}
	public void onNormalClick(){
		Application.LoadLevel("GameScreen");
		hardMode = false;
		easyMode = false;
		normMode = true;
	}

	public void onHardClick(){
		Application.LoadLevel("GameScreen");
		easyMode = false;
		normMode = false;
		hardMode = true;
	}

	public void onAchievementsClick(){
		//Activate Achievements Screen
		Social.ShowAchievementsUI();
	}
	
	public void onLeaderBoardClick(){
		//Activate LeaderBoard Screen
		Social.ShowLeaderboardUI();
	}

	public void onRateScreenClick(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.IvayloDev.WhichIsBigger");
	}
	public void onFaceBookClick(){
		Application.OpenURL("https://www.facebook.com/pages/IvayloDev/875815192505401?fref=ts");
	}

	public void onTwitterClick(){
		Application.OpenURL("https://twitter.com/IvayloDev");
	}

	public void onSoundClick(){
		//Check in which state to be 
		if(AddPoints.MusicInt == 0){
		AddPoints.MusicInt = 1;
		}else{
			AddPoints.MusicInt = 0;
		}
	}

	void Update() {

		if(BoxController.EndScreenIsActive){
			Pause.SetActive(false);
		}

		//if musicint =  disable music and change sprite
		if(AddPoints.MusicInt == 1){
			musicButt.GetComponent<Image>().sprite = MusicOffSprite;
			AudioListener.volume = 0 ;
		}else if(AddPoints.MusicInt == 0){
			musicButt.GetComponent<Image>().sprite = MusicOnSprite;
			AudioListener.volume = 1 ;
		}
		}

	}


