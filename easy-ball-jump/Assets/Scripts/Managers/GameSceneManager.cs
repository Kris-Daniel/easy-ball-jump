using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

public class GameSceneManager : MonoSingleton<GameSceneManager> {
    public int score = 0;
    public static int highScore = 0;
    public List<GameObject> ScoreObjectsInGameOver;
    
    [SerializeField]
    List<Theme> _ThemeColors;
    void Start() {
        if(PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        Theme themeColor = _ThemeColors[Random.Range(0, _ThemeColors.Count)];
        Material playerShader = PlayerController.Instance.GetComponent<Renderer>().sharedMaterial;
        playerShader.SetColor("_Color", themeColor.BallColor);
        
        Material background = BackgroundController.Instance.GetComponent<Renderer>().sharedMaterial;
        background.SetColor("_Color", themeColor.BackgroundColor);

        PlayerController.OnChangeScore += ChangeScore;
    }

    public void LoseGame() {
        PlayerController.Instance.ResetOnChangeScore();
        score--;
        highScore = score > highScore ? score : highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        UIManager.Instance.GetComponent<ButtonActions>().PauseGame("LoseMenu");
        
        foreach (var scoreObject in ScoreObjectsInGameOver) {
            scoreObject.GetComponent<IScore>().SetScore();
        }

    }

    void ChangeScore(int scoreToAdd) {
        score += scoreToAdd;
    }
    
}
