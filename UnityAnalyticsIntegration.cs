using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {

	// Use this for initialization
	void Start () {
		const string projectId = "e0688fa5-f695-41f0-9c14-a6fbe30cb763";
		UnityAnalytics.StartSDK (projectId);
	}
}
