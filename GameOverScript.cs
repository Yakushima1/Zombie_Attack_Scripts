using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI maxPointsText;
    public FirstPersonController FirstPersonController;
    public StatsController statsController;

    public void Setup(int score)
    {
        statsController.onGameOver(score);
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        maxPointsText.text = "MAX POINTS: " + statsController.getMaxScore().ToString();
        FirstPersonController.cameraCanMove = false;
    }
    public void Update()
    {
        if (gameObject.active && Input.GetKey(KeyCode.R))
        {
			Time.timeScale = 1f;
            SceneManager.LoadScene("Demo");
        }
    }
}
