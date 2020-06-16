using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformGridController : MonoBehaviour {
    public int scoreToAdd = 1;
    GameObject _platform;

    void OnEnable() {
        scoreToAdd = 1;
    }

    public void SpawnPlatform(GameObject platformToSpawn) {
        _platform = Instantiate(platformToSpawn, transform.position, Quaternion.identity);
        _platform.transform.SetParent(transform);
        _platform.GetComponent<PlatformController>().SetRandomPosition();
    }

    void Update() {
        
        float playerVelocityY = PlayerController.Instance.rigidbody.velocity.y;
        float playerPosY = PlayerController.Instance.transform.position.y;
        float moveSpeedBoost = playerVelocityY > 6f ? playerPosY * 2 : 1;

        float a = Mathf.Clamp(-playerVelocityY - playerPosY, -5f, 0f);
        

        Vector3 direction = new Vector3(0, a * Time.deltaTime, 0);
        transform.Translate(direction, Space.World);
        
        if (transform.position.y < PlatformPoolController.bottomEdge) {
            PlatformPoolController.Instance.inactivePlatformGrids.Add(gameObject);
            if (_platform != null)
                Destroy(_platform);
            gameObject.SetActive(false);
        }
        
    }
    
    
}
