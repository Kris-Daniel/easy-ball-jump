using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void LoseGame() {
        UIManager.Instance.GetComponent<ButtonActions>().PauseGame("LoseMenu");
    }
    
}
