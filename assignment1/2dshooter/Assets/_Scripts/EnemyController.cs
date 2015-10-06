//Alexander Man
//File: EnemyController.cs
//Creation Date: Sept 28, 2015
// Description: control's enemy's movements.
using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	GameObject scoreUITextGO;

	float speed;

	// Use this for initialization
	void Start () {
		speed = 1.5f;
		scoreUITextGO = GameObject.FindGameObjectWithTag ("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
		transform.position = position;
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag")) {

			scoreUITextGO.GetComponent<GameScore>().Score += 100;

			Destroy (gameObject);
		}
	}
}
