using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GameObject TIMER;
	public static float countDown = 1.48f;
	public static bool gameOver = false;
	// Use this for initialization

	void Start () {

		//this is false so the first time after restart the user has time to choose
		gameOver = false;
		//set countdown to default (Normal mode)
		countDown = 1.48f;
	}


	
	// Update is called once per frame
	void Update () {

		// possition the timer and make its' x to match the screen width
		Vector2 Timer = TIMER.transform.localScale;
		Timer.x = Camera.main.gameObject.transform.position.x + countDown;
		TIMER.transform.localScale = Timer;


		//deactivate timer if endScreen is active
		if(BoxController.EndScreenIsActive){
			TIMER.SetActive(false);
			BoxController.playDeathSound = false;
		}


		//Countdown and check if time has run out
		if(BoxController.startTimer){
			//start countdown
			// if == 0 => die
			countDown -= Time.deltaTime * 2;
			if(countDown <= 0 && !BoxController.EndScreenIsActive){
				BoxController.playDeathSound = true;
				gameOver = true;
				BoxController.EndScreenIsActive = true;
				BoxController.startTimer = false;
			}
			if(BoxController.EnableBoxClicks){
				Time.timeScale=0;
			}else{
				Time.timeScale=1;
			} 
	   	 }
    }
}