using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText; 

	private int score;

	// Use this for initialization
	void Start () {
		Reset ();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset() {
		score = 0;
		SetText ();
	}

	void SetText() {
		if (scoreText) {
			scoreText.text = "Score: " + score;
		} 
	}

	public void IncreaseScore() {
		score++;
		SetText ();
	}
}
