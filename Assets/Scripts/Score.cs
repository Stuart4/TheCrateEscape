using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static float score = 0;
	private AudioSource backgroundAudio;
	// Use this for initialization
	void Start () {
		score = 0;
		backgroundAudio = GetComponent<AudioSource>();
		backgroundAudio.Play();
		StartCoroutine(FadeAudio(5f, true));
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime;
	}

	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(score));
	}

	void startMusic() {
	}

	IEnumerator FadeAudio (float timer, bool fadeIn) {
	    float start = fadeIn ? 0.0F : 1.0F;
	    float end = fadeIn ? 1.0F : 0.0F;
	    float i = 0.0F;
	    float step = 1.0F/timer;
	 
	    while (i <= 1.0F) {
	        i += step * Time.deltaTime;
	        backgroundAudio.volume = Mathf.Lerp(start, end, i);
	        yield return new WaitForSeconds(step * Time.deltaTime);
	    }
}
}
