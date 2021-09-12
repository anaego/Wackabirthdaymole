using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject youSuckPanel;
    // I KNOW I KNOW
    public MolesController molesController;

    private int currentScore = 0;

    public void ChangeScore(int delta)
    {
        currentScore += delta;
        scoreText.text = $"Score: {currentScore}";
        if (currentScore < 0)
        {
            youSuckPanel.SetActive(true);
            // I know this shouldn't be here but it's for a low effort jam!
            molesController.StopMoleMovingCoroutine();
            molesController.ShuffleMoleHoles();
            molesController.StartMoleMovingCoroutine();
        }    }

    public void SetScore(int score)
    {
        currentScore = score;
    }
}
