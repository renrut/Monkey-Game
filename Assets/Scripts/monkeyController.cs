using UnityEngine;
using System.Collections;

public class monkeyController : MonoBehaviour {

	Animator animator;

	public void Start(){
		animator = GetComponent<Animator>();
	}
	


	public void resetMonkey(){
		animator.SetBool("isAlive", true);
		animator.SetBool("isDead", false);
				
	}


	public void killMonkey(){
		animator.SetBool("isAlive", false);
		animator.SetBool("isDead", true);
		
	}
}
