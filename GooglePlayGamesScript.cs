using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class GooglePlayGamesScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		//stuffs I dont care bout
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		
		PlayGamesPlatform.InitializeInstance(config);

		// Activate the Google Play Games platform shit
		GooglePlayGames.PlayGamesPlatform.Activate();	

			}

	void Start(){
		Social.localUser.Authenticate(
			(bool success) => {
		});
		}

	}

