using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    public int high_score;

    void Start()
    {
    	if (!PlayerPrefs.HasKey("high_score"))
    	{
    		PlayerPrefs.SetInt("high_score", 0);
    		high_score = 0;
    	}
    	else
    	{
    		high_score = PlayerPrefs.GetInt("high_score");
    	}
    }

    public void high_score_submit(int score)
    {
    	if (score > high_score)
    	{
    		high_score = score;
    		PlayerPrefs.SetInt("high_score", score);
    	}
    }
}
