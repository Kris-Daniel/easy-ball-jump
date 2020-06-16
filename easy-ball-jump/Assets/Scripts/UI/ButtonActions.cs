using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void PauseGame(string childMenuName) {
        Time.timeScale = 0;
        PausePanelController.Instance.Show(childMenuName);
    }
    public void ContinueGame() {
        PausePanelController.Instance.Hide();
        Time.timeScale = 1;
    }
    public void RestartGame() {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        if(MusicManager.Instance != null)
            MusicManager.Instance.PlayAmbientSound();
    }
    public void ExitGame() {
        Application.Quit();
    }
    
}
