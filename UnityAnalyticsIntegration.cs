using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {

	// Use this for initialization
	void Start () {
		const string projectId = "PROJECT_ID";
		UnityAnalytics.StartSDK (projectId);
	}
}
