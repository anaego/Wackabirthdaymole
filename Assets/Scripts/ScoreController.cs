using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missesText;
    public GameObject youSuckPanel;
    public AudioSource mainAudioSource;
    public AudioSource losingAudioSource;
    // I KNOW I KNOW
    public MolesController molesController;

    private int currentScore = 0;
    private int currentMisses = 0;

    public void ChangeScore(int delta)
    {
        currentScore += delta;
        scoreText.text = $"Score: {currentScore}";
        if (currentScore > 100)
        {
            // TODO
        }
    }

    public void ChangeMisses(int delta)
    {
        currentMisses += delta;
        missesText.text = $"Misses: {currentMisses}";
        if (currentMisses > 4)
        {
            mainAudioSource.Pause();
            losingAudioSource.Play();
            youSuckPanel.SetActive(true);
            // I know this shouldn't be here but it's for a low effort jam!
            molesController.StopMoleMovingCoroutine();
        }
    }

    public void ResetGame()
    {
        currentScore = 0;
        scoreText.text = $"Score: {currentScore}";
        currentMisses = 0;
        missesText.text = $"Misses: {currentMisses}";
        molesController.ShuffleMoleHoles();
        molesController.StartMoleMovingCoroutine();
        mainAudioSource.Play();
    }
}
