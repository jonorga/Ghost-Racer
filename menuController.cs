﻿/*
*** This is effectively the main operating script of the game ***

The game will start with the main menu open by default
From there, this will have functions for:
- Close all main menu gameobjects
- Start game
- Open "choose car" submenu
- Close "choose car" submenu
- Choose car: Toggle car selection
- Open "how to play" submenu
- Close "how to play" submenu
- Open "Settings" submenu
- Close "Settings" submenu
- Settings: Disable all audio
- Settings: Disable music
- Settings: Disable SFX


TODO:
- Choose car submenu, a few different basic cars with different stats
- how to play submenu, maybe just make a video that plays
- Settings submenu
- Make audio mixers for music and SFX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
	// Material applied to all UI buttons and text
	public Material button_mat;
	// Copy of ghost prefab for menu animation
	public GameObject menu_ghosts;
	// Menu gameobjects
	public GameObject gameplay_controls, main_menus;
	// Tutorial slide array
	public GameObject[] tutorial_slide = new GameObject[3];
	// Car Selector Script variable
	public carSelector _cs;
	// Car selector slide array
	public GameObject[] selector_slide = new GameObject[4];
	// Color for button material
	Color button_color = Color.white;


	public void fadeMainMenu()
	{
		StartCoroutine(fadeMainEnum());
	}

	IEnumerator fadeMainEnum()
	{
		while (button_mat.color.a > 0)
		{
			button_color.a -= 0.1f;
			button_mat.color = button_color;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(0.2f);
		main_menus.SetActive(false);
		gameplay_controls.SetActive(true);
		while (button_mat.color.a < 1)
		{
			button_color.a += 0.1f;
			button_mat.color = button_color;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(6);
		menu_ghosts.SetActive(false);
	}

	void Start()
	{
		button_mat.color = button_color;
	}

	// Method for handling tutorial slides on menu
	public void tutorialSlides(bool leftClick)
	{
		if (leftClick)
		{
			if (tutorial_slide[0].activeSelf)
			{
				tutorial_slide[2].SetActive(true);
				tutorial_slide[0].SetActive(false);
			}
			else if (tutorial_slide[1].activeSelf)
			{
				tutorial_slide[0].SetActive(true);
				tutorial_slide[1].SetActive(false);
			}
			else if (tutorial_slide[2].activeSelf)
			{
				tutorial_slide[1].SetActive(true);
				tutorial_slide[2].SetActive(false);
			}
		}
		else
		{
			if (tutorial_slide[0].activeSelf)
			{
				tutorial_slide[1].SetActive(true);
				tutorial_slide[0].SetActive(false);
			}
			else if (tutorial_slide[1].activeSelf)
			{
				tutorial_slide[2].SetActive(true);
				tutorial_slide[1].SetActive(false);
			}
			else if (tutorial_slide[2].activeSelf)
			{
				tutorial_slide[0].SetActive(true);
				tutorial_slide[2].SetActive(false);
			}
		}
	}

	// Method for handling car selection on menu
	public void carSelection(bool leftClick)
	{
		// Selector slide 1: default car, as is currently
		// Selector slide 2: Car 2, make other color
		// Selector slide 3: Car 3, make other color
		// Selector slide 4: More coming soon...
	}
}
