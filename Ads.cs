using UnityEngine;
using System.Collections;
using GoogleMobileAds;

public class Ads : MonoBehaviour {

	private AdMobPlugin admob;
	private const string Interstitial_ID = "ca-app-pub-4847787002677683/9274711456";
	private const string AD_UNIT_ID = "ca-app-pub-4847787002677683/9774239057";
	public static int adCount = 0;	

	void Awake() {
		admob = GetComponent<AdMobPlugin>();
		admob.CreateBanner(AD_UNIT_ID, AdMobPlugin.AdSize.SMART_BANNER, true, Interstitial_ID);
		if(adCount == 1){
		admob.RequestInterstitial();
	}
}
	
	void Update() {
			HandleInterstitialLoaded();
	}
	void OnEnable() {
		AdMobPlugin.InterstitialLoaded += HandleInterstitialLoaded;
	}
	
	void OnDisable() {
		AdMobPlugin.InterstitialLoaded -= HandleInterstitialLoaded;
	}
	
	public void HandleInterstitialLoaded() {
	if(BoxController.EndScreenIsActive && adCount == 2){
	 		admob.ShowInterstitial();
				adCount = 0;

		}
	}
}
