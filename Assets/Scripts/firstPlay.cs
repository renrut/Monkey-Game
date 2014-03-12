using UnityEngine;
using System.Collections;

public class firstPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0 && renderer.enabled && Input.GetTouch(0).phase == TouchPhase.Ended){
			renderer.enabled = false;
		}
		else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
			Application.LoadLevel(0);
		
		}
	}
}
