using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenScore : MonoBehaviour {

	public static Text EndScore;

	// Use this for initialization
	void Start () {

		//just getting the text component
		EndScore = GetComponent<Text>();
	}
	
}
