using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    void Start() {
        PlayerController.OnChangeScore += UpdateScore;
    }

    void UpdateScore(int scoreToAdd) {
        gameObject.GetComponent<Text>().text = "Score: " + GameSceneManager.Instance.score;
    }

    void OnDestroy() {
        PlayerController.OnChangeScore -= UpdateScore;
    }
}
