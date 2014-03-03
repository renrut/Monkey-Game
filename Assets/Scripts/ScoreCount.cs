using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {

	public int count;
	public MeshRenderer textRenderer;
	public TextMesh scoreText;
	public int highScore;

	public bool scoreIsNew;
	//set the score text to the very front

	// Use this for initialization
	void Start () {
		textRenderer.sortingLayerName = "score";
		scoreText.text = count.ToString();
		highScore = PlayerPrefs.GetInt("Highscore", 0);
		scoreIsNew = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ScoreUpdate(){
		++count;
		scoreText.text = count.ToString();
	}
	public void ScoreReset(){
		newHighscore ();
		count = 0;
		scoreText.text = count.ToString();
	}
	public void newHighscore(){
		highScore = PlayerPrefs.GetInt("Highscore", 0);
		if(count > highScore){
			PlayerPrefs.SetInt("Highscore", count);
			scoreIsNew = true;
		}
	}
}
