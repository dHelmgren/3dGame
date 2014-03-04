﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnGUI()
	{
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(100,540,120,50), "Start Game")) {
			Application.LoadLevel("chandyinRoom");
		}

		// Make the second button.
		if(GUI.Button(new Rect(260,540,120,50), "How to Play")) {
			Application.LoadLevel("ControlInfo");
		}

		if(GUI.Button(new Rect(580,540,120,50), "Game Credits")) {
			Application.LoadLevel("GameCredits");
		}
		
		if(GUI.Button(new Rect(740,540,120,50), "Quit Game")) {
			Application.Quit();
		}
		
		
	}
	
}
