using UnityEngine;
using System.Collections;

/**
 * This can be used for either rainburst or rainSplash depending on which prefab is called
 * both will change the sprites a certain number of seconds
 * For rainSplash, we need another script to affect the gameplay
 */
public class Raindeath : MonoBehaviour {
	
	public Sprite[] deathSprites;
	private SpriteRenderer spriteRenderer;

	//just like in startRain, this will do something every certain frames rather than every frame
	//in this case, we change the death sprite
	//For example, with 6 framesPerSprite and 60 fps, there will be 10 sprite changes every second
	private int frameTimer; 
	public int framesPerSprite;

	private int index;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
		index = 0;
		frameTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//whenever frameTimer equals framesPerSprite, change the sprite
		frameTimer++;
		if(frameTimer == framesPerSprite){
			spriteRenderer.sprite = deathSprites[ index ];
			index++;
			//delete the object once all the sprites have passed
			if(index == deathSprites.Length - 1){
				audio.Play();
				Destroy (this.gameObject);
			}
			//restart frameTimer for next sprite change
			frameTimer = 0;
		}

	}
}
