using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public void onGameOver(int score)
    {		
        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", score);
            PlayerPrefs.Save();
        }
    }

    public int getMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore", 0);
    }
}
