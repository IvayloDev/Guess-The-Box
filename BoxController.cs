using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class BoxController : MonoBehaviour {

	Camera cam;
	public GameObject EndScreen;
	public GameObject Box;
	public GameObject Box2;
	public static bool addPoint = false;
	public static bool startTimer = false;
	//if EndScreenIsActive you cant click boxes(use for pause menu)
	public static bool EndScreenIsActive = false;
	public static bool EnableBoxClicks = false;
	public static int level = 1;
	public RaycastHit rhInfo;
	public Color[] colors = new Color[7];
	public AudioClip[] 	audioClip;
	public Color blue = new Color();
	public Color green = new Color();
	public Color orange = new Color();
	public Color orange2 = new Color();
	public Color gray = new Color();
	public Color purple = new Color();
	public Color red = new Color();
	public float levelScale;
	public static bool playDeathSound = false;

	public Animator endscreenAnim;

	//in update - static local scale of gfx and var of x 
	//which is changes over time in update

	void Start () {
		startTimer = false;
		cam = GetComponent<Camera>();
		EndScreen.SetActive(false);
		EndScreenIsActive = false;
		EnableBoxClicks = false;
		playDeathSound = false;
		
		level = 1;
		genLevel(level);

		colors[0] = blue;	
		colors[1] = green;
		colors[2] = orange;
		colors[3] = orange2;
		colors[4] = gray;
		colors[5] = purple;
		colors[6] = red;
		
		

		cam.backgroundColor = colors[Random.Range(0, colors.Length)];

		// Set new BG color at very first start of game
		//cam.backgroundColor = Random.Range(;
		if(Social.localUser.authenticated){
		Social.ReportScore(AddPoints.HighScoreEasy,"",(bool success) => {
		});
		Social.ReportScore(AddPoints.HighScoreNorm,"",(bool success) => {
		});
		Social.ReportScore(AddPoints.HighScoreHard,"",(bool success) => {
		});
		}
	}

	void genLevel(int level) {
		//Controls difference is scale
		if(level > 50){
			level = 10;
		}
		float levelCoef = 0.3f;
		levelScale = Random.Range(0.7000f,1.1000f) - Mathf.Min(0.2f, 0.2f*Mathf.Sqrt(level)/100f);//0.2f
		float scale1 = levelScale + levelCoef/Mathf.Sqrt(level);
		float scale2 = levelScale - levelCoef/Mathf.Sqrt(level);
		float big = Random.Range(0f, 1f);

		//if(AddPoints.Score > 70){
		//	levelScale = Random.Range(0.700f, 1.1000f);
		//}

		//Make First boxes random
		Vector2 Scale = Box.transform.localScale;
		Scale.x = big>0.5f ? scale1 : scale2;
		//Scale.x = Random.Range(minScale, maxScale);
		Scale.y = Scale.x;
		Box.transform.localScale = Scale;
		
		Scale = Box2.transform.localScale;
		//Scale.x = Random.Range(minScale, maxScale);
		Scale.x = big>0.5f ? scale2 : scale1;
		Scale.y = Scale.x;
		Box2.transform.localScale = Scale;

	}


	void LoadNextLevel(){

		//Gen next level, 
		//play "correct" sound and start timer 


		genLevel(level++);
		startTimer = true;
		PlaySound(0);
		

	}

	// music handler
	public void PlaySound(int clip){

	GetComponent<AudioSource>().clip = audioClip[clip];
	GetComponent<AudioSource>().Play();
	}

	void Update() {

		

		//if timer is over
		if(Timer.gameOver){
			endscreenAnim.SetBool("IsUserDead", true);
			EndScreen.SetActive(true);
			EndScreenIsActive = true;
			if(playDeathSound){
				PlaySound(1);

			}
		}

		//if endscreen is active set up the score and highscore for each gamemode
		if(EndScreenIsActive && AddPoints.HighScoreEasy != null){
			if(ButtonsScript.easyMode){
			HighScoreScript.HighScoreText.text = "" + AddPoints.HighScoreEasy;
			EndScreenScore.EndScore.text = "" + AddPoints.Score;
			if(AddPoints.Score >= AddPoints.HighScoreEasy){
				AddPoints.HighScoreEasy = AddPoints.Score;
				startTimer = false;
			}
		}

			if(ButtonsScript.hardMode){
				HighScoreScript.HighScoreText.text = "" + AddPoints.HighScoreHard;
				EndScreenScore.EndScore.text = "" + AddPoints.Score;
				if(AddPoints.Score >= AddPoints.HighScoreHard){
					AddPoints.HighScoreHard = AddPoints.Score;
					startTimer = false;
				}
			}

			if(ButtonsScript.normMode){
				HighScoreScript.HighScoreText.text = "" + AddPoints.HighScoreNorm;
				EndScreenScore.EndScore.text = "" + AddPoints.Score;
				if(AddPoints.Score >= AddPoints.HighScoreNorm){
					AddPoints.HighScoreNorm = AddPoints.Score;
					startTimer = false;
				}	
			}
		}


		//If the user is playing 
		if(!EndScreenIsActive){

			if(!EnableBoxClicks){
			//check for input on boxess
		if(Input.GetMouseButtonDown(0)){
			Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
			 if(Physics.Raycast(toMouse, out rhInfo, 100.0f));

				//if the box is the top
			if(rhInfo.transform.name == "Box-Up"){
					//if the top box is bigger than bottom box
				if(Box.transform.localScale.sqrMagnitude > Box2.transform.localScale.sqrMagnitude){
						addPoint = true;
						//set timer for the gamemodes
						if(ButtonsScript.easyMode){
							Timer.countDown = 2.3f;
						}else if(ButtonsScript.hardMode){
							Timer.countDown = 1f;
						}else if(ButtonsScript.normMode){
							Timer.countDown = 1.35f;
						}
						LoadNextLevel();
				}else{
						//activate endscreen if user is wrong
						EndScreenIsActive = true;
						EndScreen.SetActive(true);
						endscreenAnim.SetBool("IsUserDead", true);
						PlaySound(1);
						Ads.adCount++;
					}

					if(AddPoints.Score >= 10 && ButtonsScript.hardMode){
						//if the mode is hard and score >10 gen random color for box
				Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
				Box.GetComponent<Renderer>().material.color = newColor;
					}

			}else if(rhInfo.transform.name == "Box-Down"){
				//if the box is the bottom
				if(Box2.transform.localScale.sqrMagnitude > Box.transform.localScale.sqrMagnitude){
						//if the bottom box is bigger than the top box
						addPoint = true;
						//set timer for gamemodes
						if(ButtonsScript.easyMode){
							Timer.countDown = 2.1f;
						}else if(ButtonsScript.hardMode){
							Timer.countDown = 1f;
						}else if(ButtonsScript.normMode){
							Timer.countDown = 1.35f;
						}
						LoadNextLevel();
				}else{
						//activate endscreen if user guessed wrong
						EndScreenIsActive = true;
						EndScreen.SetActive(true);
						endscreenAnim.SetBool("IsUserDead", true);
						PlaySound(1);
						Ads.adCount++;
					}

					if(AddPoints.Score >= 10 && ButtonsScript.hardMode){
						//if mode is hard and score >10 gen random color
				Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
				Box2.GetComponent<Renderer>().material.color = newColor;
						} 
					}
		     }
	    	}
		}
	}
}
