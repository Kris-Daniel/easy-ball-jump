using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Platforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformPoolController : MonoSingleton<PlatformPoolController> {
    [SerializeField] GameObject _platformGrid;

    public List<GameObject> platforms;
    public List<GameObject> inactivePlatformGrids;
    int _gridAmount = 15;
    int _groundOffset = 2;
    int _gridHeight = 2;
    public static float leftEdge = -5.5f;
    public static float rightEdge = 5.5f;
    public static float bottomEdge = -6f;
    [HideInInspector]
    public float topEdge;

    int _lastPlatformID = -1;

    void Start() {
        topEdge = _groundOffset + (_gridAmount * _gridHeight) + bottomEdge;
        for (var i = 0; i < _gridAmount; i++) {
            GameObject platformGrid = Instantiate(_platformGrid, new Vector3(0, (i + _groundOffset) * _gridHeight, 0),
                Quaternion.identity);
            platformGrid.transform.SetParent(transform);
            SpawnRandomPlatform(platformGrid);
        }
    }

    int GetRandomPlatformID() {
        int platformID = Random.Range(0, platforms.Count);
        // Decrease chance for red platforms
        if(platformID == _lastPlatformID && platformID == 3)
            platformID = Random.Range(0, platforms.Count - 1);

        _lastPlatformID = platformID;
        return platformID;
    }

    void SpawnRandomPlatform(GameObject platformGrid) {
        int spawnProbability = Random.Range(0, 10);
        if(spawnProbability > 0)
            platformGrid.GetComponent<PlatformGridController>().SpawnPlatform(platforms[GetRandomPlatformID()].gameObject);
    }


    void Update() {
        if (inactivePlatformGrids.Count > 0) {
            var inactivePlatformGrid = inactivePlatformGrids[0];
            inactivePlatformGrid.SetActive(true);
            inactivePlatformGrid.transform.position = new Vector3(0, topEdge, 0);
            SpawnRandomPlatform(inactivePlatformGrid);
            inactivePlatformGrids.Remove(inactivePlatformGrid);
        }
    }
}