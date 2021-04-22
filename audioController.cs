using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
	public AudioSource MU_gameplay, MU_pause, ghosted, point;
	carAudio car_audio;
	bool pause = false;

	void Start()
	{
		GameObject car_audioGO = GameObject.FindGameObjectWithTag("Player");
		car_audio = car_audioGO.GetComponent<carAudio>();
	}

	public void pauseGame()
	{
		pause = !pause;

		if (MU_gameplay.isPlaying || MU_pause.isPlaying)
		{	
			if (pause)
			{
				int samp = MU_gameplay.timeSamples;
				MU_pause.timeSamples = samp;
				MU_gameplay.Stop();
				MU_pause.Play();
			}
			else
			{
				int samp = MU_pause.timeSamples;
				MU_gameplay.timeSamples = samp;
				MU_pause.Stop();
				MU_gameplay.Play();
			}
		}
	}

	public void startGameplayMusic()
	{
		MU_gameplay.Play();
	}

	public void playGameover()
	{
		car_audio.gameover = true;
		ghosted.Play();
		MU_gameplay.Stop();
		MU_pause.Stop();
	}

	public void playPoint()
	{
		point.Play();
	}
}
