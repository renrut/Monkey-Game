using UnityEngine;
using System.Collections;

public class RaindropFall : MonoBehaviour {


	public float dropSpeed;

	//sprite array to change when droppng
	public Sprite[] dropSprites;

	//affects sprite switching
	public float framesPerSecond;

//	private SpriteRenderer spriteRenderer;

	//these are for instantiating the objects. all are prefabs
	public GameObject waterLevel;
	public GameObject rainBurst;
	public GameObject rainSplash;

	//public TextMesh score;


	private startRain rainfall;
	// Use this for initialization
	void Start () {
//		spriteRenderer = renderer as SpriteRenderer;
		rainfall =  GameObject.FindGameObjectWithTag("rainfall").GetComponent<startRain>();
	}
	
	// Update is called once per frame
	void Update () {
		//check if tapped
		if(!rainfall.firstStart){
			if(Input.touchCount > 0){
				//only one touch input at a time, so choose the first one
				Touch touch = Input.GetTouch(0);

				//find the world point that was touched 
				Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
				//convert this to a 2d vector
				Vector2 touchPos = new Vector2(wp.x, wp.y);

				//if the touch point overlapped with our collider
				if (collider2D == Physics2D.OverlapPoint (touchPos)){
					//find the score object in the hierarchy and update it
					GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().ScoreUpdate();
					//replace this object with a rainBurst
					Instantiate (rainBurst, transform.position,transform.rotation);
					Destroy (this.gameObject);
				}
			}

			/*if(Input.GetMouseButtonDown(0)){
					//find the score object in the hierarchy and update it
					GameObject.FindGameObjectWithTag("score").GetComponent<ScoreCount>().ScoreUpdate();
					//replace this object with a rainBurst
					Instantiate (rainBurst, transform.position,transform.rotation);
					Destroy (this.gameObject);
					
			}*/
		}
		//change droppng sprite
		//I don't like the tutorial's implementation of this. it works for the falling rain,
		//but not for the burst or splash

		/*
		 * The sprites look too similar for this to do any good right now
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % dropSprites.Length;
		spriteRenderer.sprite = dropSprites[ index ];
		*/


		//drop the position straight down to the y-value of the waterLevel
		//TODO maybe give it an x-value target too
		Vector3 target = new Vector3 (transform.position.x, -10 ,0);
		transform.position = Vector3.Lerp(transform.position, target,
		                                  Time.deltaTime * dropSpeed);
		
		if(!rainfall.started && !rainfall.firstStart){
			Destroy (this.gameObject);
		}
	}

	void OnCollisionStay2D( Collision2D other){
		//don't want rain colliding with other rain
		if(rainfall.firstStart && other.gameObject.tag == "waterlevel"){
			Instantiate (rainSplash, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
		if(!rainfall.firstStart && other.gameObject.tag == "waterlevel"){
			//lose
			rainfall.checkForEndGame();
			//replace this object with a rainsplash for OOP style
			Instantiate(rainSplash,transform.position,transform.rotation);
			Destroy (this.gameObject);
		}
	}


}
