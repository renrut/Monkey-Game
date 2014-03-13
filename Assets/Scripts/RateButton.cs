using UnityEngine;
using System.Collections;

public class RateButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
					renderer.enabled = false;
					GameObject.FindGameObjectWithTag("ratedown").renderer.enabled = true;
				}
			}
			if(touch.phase == TouchPhase.Ended){
				renderer.enabled = true;
				GameObject.FindGameObjectWithTag("ratedown").renderer.enabled = false;
				
				
				//find the world point that was touched 
				Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
				//convert this to a 2d vector
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				
				//if the touch point overlapped with our collider
				if (collider2D == Physics2D.OverlapPoint (touchPos)){
					//Application.OpenURL(our application url);
					#if UNITY_ANDROID
						//Application.OpenURL("http://play.google.com/store/apps/details?id=com.murner.rainymonkey
						Application.OpenURL("http://play.google.com");
					#endif

					#if UNITY_IPHONE
						//Application.openURL("http://store.apple.com");
					#endif
				}
			}
		}
		/*if(Input.GetButtonDown("Fire1")){
			GameObject.FindGameObjectWithTag("rateup").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.FindGameObjectWithTag("ratedown").GetComponent<SpriteRenderer>().enabled = true;


		}

		if(Input.GetButtonUp("Fire1")){
			GameObject.FindGameObjectWithTag("rateup").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.FindGameObjectWithTag("ratedown").GetComponent<SpriteRenderer>().enabled = false;
			
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos = new Vector2(wp.x,wp.y);
			if (collider2D == Physics2D.OverlapPoint (mousePos)){
				//find the score object in the hierarchy and update it
				Application.OpenURL("http://google.com");
				
			}
		}*/
	}
}
