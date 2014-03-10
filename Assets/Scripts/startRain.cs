using UnityEngine;
using System.Collections;

/*
 * Controller for starting the rainfall.
 * Rain will begin falling once the start button is pushed
 * Rain falls every 120 calls to Update (every 2 seconds at 60fps)
 * This timing of rain can be substituted for something random if you have a better idea, but it works
 */
public class startRain : MonoBehaviour {

	//the prefab to be instantiated
	public Rigidbody2D raindrop;
	public GameObject gameMenu;
	public float numDropsToHit;
	private float numDropsHit;

	public bool firstStart;
	
	
	//the range of random x-values to be generated
	public float randomSize;

	//has the game started yet?
	public bool started;
	//the timing of rain
	//every Update, rainTimer is incremented
	public int rainTimer;
	//every framesPerRain (determined by rainTimer), Update will create a new rainDrop
	public int framesPerRain;
	// Use this for initialization
	void Start () {
		started = false;
		numDropsHit = 0;
		firstStart = true;

	}



	// Update is called once per frame
	void Update () {
	


		//Once the mouse is clicked, start the game
		//TODO change this to clicking a menu start button
		if(started || firstStart){
			//increment rainTimer every frame until it hits framesPerRain, then create a raindrop
			rainTimer++;
			if(rainTimer == framesPerRain){
				//the position of the new rain
				Vector3 rainPos = transform.position;
				//give it a random x-value
				rainPos.x = Random.value * randomSize + transform.position.x;
				//create the rain prefab
				Instantiate (raindrop, rainPos, transform.rotation);
				//restart the rain timer
				rainTimer = 0;
			}
		}
	}
	public void startGame(){
		GameObject.FindGameObjectWithTag("monkey").GetComponent<monkeyController>().resetMonkey();
		GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().ScoreReset();
		GameObject.FindGameObjectWithTag("waterlevel").GetComponent<WaterLevel>().reset();
		started = true;
		if(firstStart){
			Destroy (GameObject.FindGameObjectWithTag("title"));
			Object[] rain = GameObject.FindGameObjectsWithTag("rain");
			for(int i = 0; i < rain.Length; ++i){
				Destroy(rain[i]);
			}
			Destroy (GameObject.FindGameObjectWithTag("rateup"));
			GameObject.FindGameObjectWithTag("score").renderer.enabled = true;
			firstStart = false;
		}
	}

	public void checkForEndGame(){
		numDropsHit++;
		if (numDropsHit>=numDropsToHit){
			endGame();
		}
	}

	public void endGame(){
		started = false;
		numDropsHit = 0;
		GameObject.FindGameObjectWithTag("monkey").GetComponent<monkeyController>().killMonkey();
		GameObject menu = Instantiate (gameMenu) as GameObject;
		menu.SetActive(false);
		menu.audio.Play();
		StartCoroutine(showMenu(menu));



	}
	IEnumerator showMenu(GameObject menu){
		yield return new WaitForSeconds(.70f);
		menu.SetActive(true);
	}
}

