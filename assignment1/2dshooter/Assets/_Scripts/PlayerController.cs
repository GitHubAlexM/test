//Alexander Man
//File: PlayerController.cs
//Creation Date: Sept 28, 2015
// Description: This script manages the main player game object, it's firing of bullets, and a shooting sound.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject GameManagerGO;


	public GameObject PlayerBulletGO;
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;

	public AudioClip test;
	private AudioSource source;

	public Text LivesUIText;

	const int MaxLives = 3;

	int lives;

	public float speed;

	public void Init()
	{

		lives = MaxLives;
		LivesUIText.text = lives.ToString ();
		transform.position = new Vector2 (0, 0);
		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			if (source.isPlaying) source.Stop();
			else source.Play();
			GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
			bullet01.transform.position = BulletPosition01.transform.position;

			GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
			bullet02.transform.position = BulletPosition02.transform.position;
		}

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;
		Move (direction);

	}
	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max =  Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		max.y = max.y - 0.225f;
		min.y = min.y + 0.225f;

		Vector2 pos = transform.position;
		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		   {
			lives--;
			LivesUIText.text = lives.ToString();

			if(lives == 0){
				GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
				gameObject.SetActive(false);
			}
		}
	}
}
