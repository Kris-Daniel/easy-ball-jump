using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
    public void PauseGame() {
    
    }
    public void ResumeGame() {
    
    }
    public void RestartGame() {
    
    }
    public void ExitGame() {
        Application.Quit();
    }
    
}
