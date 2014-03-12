using UnityEngine;
using System.Collections;

public class Playbutton : MonoBehaviour {

	public Rigidbody2D raindrop;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(gameObject.layer, raindrop.gameObject.layer);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0){
			//only one touch input at a time, so choose the first one
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){
				Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
				//convert this to a 2d vector
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				
				//if the touch point overlapped with our collider
				if (collider2D == Physics2D.OverlapPoint (touchPos)){
					GameObject.FindGameObjectWithTag("startup").GetComponent<SpriteRenderer>().enabled = false;
					GameObject.FindGameObjectWithTag("startdown").GetComponent<SpriteRenderer>().enabled = true;
				}
			}
			if(touch.phase == TouchPhase.Ended){
				GameObject.FindGameObjectWithTag("startup").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("startdown").GetComponent<SpriteRenderer>().enabled = false;

			
				//find the world point that was touched 
				Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
				//convert this to a 2d vector
				Vector2 touchPos = new Vector2(wp.x, wp.y);
			
				//if the touch point overlapped with our collider
				if (collider2D == Physics2D.OverlapPoint (touchPos)){
					GameObject.FindGameObjectWithTag("rainfall").GetComponent<startRain>().startGame();
				}
			}
		}


	

		/*if(Input.GetButtonDown("Fire1")){
			GameObject.FindGameObjectWithTag("startup").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.FindGameObjectWithTag("startdown").GetComponent<SpriteRenderer>().enabled = true;


		}

		if(Input.GetButtonUp("Fire1")){
			GameObject.FindGameObjectWithTag("startup").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.FindGameObjectWithTag("startdown").GetComponent<SpriteRenderer>().enabled = false;
			
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos = new Vector2(wp.x,wp.y);
			if (collider2D == Physics2D.OverlapPoint (mousePos)){
				//find the score object in the hierarchy and update it
				GameObject.FindGameObjectWithTag("rainfall").GetComponent<startRain>().startGame();
				Destroy (this.gameObject);
				
			}
		}*/
	}
}
