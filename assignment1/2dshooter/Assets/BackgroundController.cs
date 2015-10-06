//Alexander Man
//File: BackgroundController.cs
//Creation Date: Sept 28, 2015
// Description: This script contains the gameObject's movement.

using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed;
	// Use this for initialization
	void Start () {
		this._Reset ();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = new Vector2 (0.0f, 0.0f);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= speed;
		//move background
		gameObject.GetComponent<Transform> ().position = currentPosition;
		//Top Boundary Check - gameObject meets top of camera viewport
		if (currentPosition.y <= -5) {
			this._Reset();
		}
	}
	//Reset our game object
	private void _Reset(){
		Vector2 resetPosition = new Vector2 (0.0f, 5);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
