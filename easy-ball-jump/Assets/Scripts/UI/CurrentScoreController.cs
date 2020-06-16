using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreController : MonoBehaviour, IScore {
    public Text text { get; set; }
    void Start() {
        text = gameObject.GetComponent<Text>();
    }

    public void SetScore() {
        gameObject.GetComponent<Text>().text = "Current Score: " + GameSceneManager.Instance.score;
    }
}
