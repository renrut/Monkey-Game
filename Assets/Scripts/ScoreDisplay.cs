using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	public MeshRenderer highscoreRenderer;
	public TextMesh highscoreText;

	public MeshRenderer currentScoreRenderer;
	public TextMesh currentScoreText;

	public MeshRenderer newHighScore;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().newHighscore();
		highscoreRenderer.sortingLayerName = "score";
		currentScoreRenderer.sortingLayerName = "score";
		highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
		currentScoreText.text = "Current: " + GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().count;
		if(GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().scoreIsNew){
			newHighScore.sortingLayerName = "score";
			GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().scoreIsNew = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
