using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    public Text ScoreText;
    public Text ShotsRemainingText;
    public GameObject GameOverOverlay;

    void OnEnable()
    {
        RefactoredPlayerController.Instance.GameOver += HandleGameOver;
        RefactoredPlayerController.Instance.OnShot += HandleShot;
    }

    void OnDisable()
    {
        RefactoredPlayerController.Instance.GameOver -= HandleGameOver;
        RefactoredPlayerController.Instance.OnShot -= HandleShot;
    }

    void HandleGameOver()
    {
        GameOverOverlay.SetActive(true);
    }

    void HandleShot()
    {
        int score = GameController.GetScore();
        int shotsRemaining = RefactoredPlayerController.Instance.ShotsRemaining;

        ScoreText.text = $"Score: {score}";
        ShotsRemainingText.text = $"Shots Remaining: {shotsRemaining}";
    }
    protected override GameControllerBase GameController => throw new System.NotImplementedException();
}
