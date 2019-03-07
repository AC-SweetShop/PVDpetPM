using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private PetMovement pet;


	// Use this for initialization
	void Start () {
		pet = GetComponentInParent<PetMovement>();

	}
	
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D other) {
		if(other.gameObject.tag== "ground"){
		pet.grounded=true;
		}
	}


	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag =="ground"){
		pet.grounded=false;
		}
	}
}
