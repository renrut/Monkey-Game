using UnityEngine;
using System.Collections;

public class WaterLevel : MonoBehaviour {
	public float riseSpeed;
	public float increment;
	public Vector3 origPosition;

	// Use this for initialization
	void Start () {
		origPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionStay2D( Collision2D other){
		//give raindrop prefab "rain" tag
		if(other.gameObject.tag == "rain"){
			Vector3 target = new Vector3 (transform.position.x, (transform.position.y + increment), 0);
			transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * riseSpeed);
		}
	}


	public void reset(){
		transform.position = origPosition;
	}


}
