using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	public MeshRenderer titleRenderer;
	// Use this for initialization
	void Start () {
		titleRenderer = renderer as MeshRenderer;
		titleRenderer.sortingLayerName = "score";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
