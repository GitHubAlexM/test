//Alexander Man
//File: GameScore.cs
//Creation Date: Sept 28, 2015
// Description: This script manages the game score.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {
	Text scoreTextUI;
	int score;
	public int Score
	{
		get{
			return this.score;
		}
		set{
			this.score = value;
			UpdateScoreTextUI();
		}
	}
	// Use this for initialization
	void Start () {
		scoreTextUI = GetComponent<Text> ();
	}
	void UpdateScoreTextUI()
	{
		string scoreStr = string.Format ("{0:0000000}", score);
		scoreTextUI.text = scoreStr;
	}
}

