using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Platforms;
using UnityEngine;

public class PlatformPoolController : MonoBehaviour {
    [SerializeField]
    GameObject _platformGrid;

    public List<GameObject> platforms;
    byte _height = 15;
    public static float leftEdge = -5.5f;
    public static float rightEdge = 5.5f;
    
    void Start()
    {
        for (var i = 0; i < _height; i++) {
            GameObject platformGrid = Instantiate(_platformGrid, new Vector3(0, i * 2, 0), Quaternion.identity);
            platformGrid.transform.SetParent(transform);
            platformGrid.GetComponent<PlatformGridController>().SpawnPlatform(platforms[GetRandomPlatformID()].gameObject);
        }
    }

    int GetRandomPlatformID() {
        return Random.Range(0, platforms.Count);
    }
}
