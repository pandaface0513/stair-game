﻿using UnityEngine;
using System.Collections;

public class playScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playGame()
	{
		Debug.Log("Button was pressed");
		Application.LoadLevel("main");
	}
}
