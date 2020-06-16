using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class GameSceneManager : MonoSingleton<GameSceneManager> {
    public int score = 0;
    public static int highScore = 0;
    public GameObject inGameScore;
    public List<GameObject> ScoreObjectsInGameOver;


    [SerializeField] List<Theme> _ThemeColors;

    void Start() {
        try {
            
            if (PlayerPrefs.HasKey("HighScore"))
                highScore = PlayerPrefs.GetInt("HighScore");
            Theme themeColor = _ThemeColors[Random.Range(0, _ThemeColors.Count)];
            Material playerShader = PlayerController.Instance.GetComponent<Renderer>().sharedMaterial;
            playerShader.SetColor("_Color", themeColor.BallColor);

            ParticleSystem.MainModule main = PlayerController.Instance.particleSystem.GetComponent<ParticleSystem>()
                .main;
            main.startColor = themeColor.BallColor;

            Material background = BackgroundController.Instance.GetComponent<Renderer>().sharedMaterial;
            background.SetColor("_Color", themeColor.BackgroundColor);

            PlayerController.OnChangeScore += ChangeScore;
            
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public void LoseGame() {
        score--;
        if(MusicManager.Instance != null)
            MusicManager.Instance.PlayGameOverSound();
        PlayerController.Instance.ResetOnChangeScore();
        highScore = score > highScore ? score : highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        UIManager.Instance.GetComponent<ButtonActions>().PauseGame("LoseMenu");
        inGameScore.GetComponent<ScoreController>().UpdateScore(0);
        foreach (var scoreObject in ScoreObjectsInGameOver) {
            scoreObject.GetComponent<IScore>().SetScore();
        }
    }

    void ChangeScore(int scoreToAdd) {
        score += scoreToAdd;
    }
}