/*
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
	public Material button_mat;
	public GameObject menu_ghosts;
	public GameObject gameplay_controls, main_menus;
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
}
