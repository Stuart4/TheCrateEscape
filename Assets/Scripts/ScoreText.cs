using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
	public Text scoreText;
	public Text highText;
	// Use this for initialization
	void Start () {
		int score = (int) Score.score;
		if (scoreText != null)
			scoreText.text = "Score: " + score;
		int high = PlayerPrefs.GetInt("highscore", 0);
		if (score > high) {
			PlayerPrefs.SetInt("highscore", score);
			high = score;
			highText.color = Color.red;
		}
		highText.text = "High Score: " + high;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
