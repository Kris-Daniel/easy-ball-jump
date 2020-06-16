using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetectorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, PlatformPoolController.Instance.bottomEdge, 0);
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            GameSceneManager.Instance.LoseGame();
        }
    }
}
