using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformGridController : MonoBehaviour {

    GameObject _platform;

    public void SpawnPlatform(GameObject platformToSpawn) {
        _platform = Instantiate(platformToSpawn, transform.position, Quaternion.identity);
        _platform.transform.SetParent(transform);
        _platform.GetComponent<PlatformController>().SetRandomPosition();
    }

    void Update() {
        if (_platform == null) return;
        
        if (transform.position.y < -10f) {
            PlatformPoolController.Instance.inactivePlatformGrids.Add(gameObject);
            Destroy(_platform);
            gameObject.SetActive(false);
            return;
        }
        
        float playerVelocityY = PlayerController.Instance.rigidbody.velocity.y;
        float playerPosY = PlayerController.Instance.transform.position.y;
        float moveSpeedBoost = playerPosY > 10f ? playerPosY : 1;

        if (playerVelocityY > 0) {
            Vector3 direction = new Vector3(0, (-playerVelocityY - moveSpeedBoost) * Time.deltaTime, 0);
            transform.Translate(direction, Space.World);
        }
        else {
            
            Vector3 direction = new Vector3(0, -moveSpeedBoost * Time.deltaTime, 0);
            transform.Translate(direction, Space.World);
        }
    }
}
