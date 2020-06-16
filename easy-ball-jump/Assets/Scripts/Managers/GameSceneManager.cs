using System.Collections;
using System.Collections.Generic;
using Helpers;
using ScriptableObjects;
using UnityEngine;

public class GameSceneManager : MonoSingleton<GameSceneManager> {
    [SerializeField]
    List<Theme> _ThemeColors;
    void Start() {
        Theme themeColor = _ThemeColors[Random.Range(0, _ThemeColors.Count)];
        
        Material playerShader = PlayerController.Instance.GetComponent<Renderer>().sharedMaterial;
        playerShader.SetColor("_Color", themeColor.BallColor);


    }

    public void LoseGame() {
        UIManager.Instance.GetComponent<ButtonActions>().PauseGame("LoseMenu");
    }
    
}
