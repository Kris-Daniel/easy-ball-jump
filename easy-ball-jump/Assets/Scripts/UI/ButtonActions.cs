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
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        PausePanelController.Instance.Show(childMenuName);
    }
    public void ContinueGame() {
        PausePanelController.Instance.Hide();
        Time.timeScale = 1;
        Debug.Log("Continue Game");
    }
    public void RestartGame() {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void ExitGame() {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    
}
