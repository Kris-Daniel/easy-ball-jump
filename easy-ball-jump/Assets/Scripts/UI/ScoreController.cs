using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public Text text;
    void Start() {
        text = gameObject.GetComponent<Text>();
        PlayerController.OnChangeScore += UpdateScore;
    }

    void UpdateScore(int scoreToAdd) {
        text.text = "Score: " + GameSceneManager.Instance.score;
    }
}
