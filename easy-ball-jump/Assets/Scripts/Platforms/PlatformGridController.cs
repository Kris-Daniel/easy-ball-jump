using System;
using System.Collections;
using System.Collections.Generic;
using Platforms;
using UnityEngine;

public class PlatformGridController : MonoBehaviour
{
    public void SpawnPlatform(GameObject platformToSpawn) {
        GameObject platform = Instantiate(platformToSpawn, transform.position, Quaternion.identity);
        platform.transform.SetParent(transform);
        platform.GetComponent<PlatformController>().SetRandomPosition();
    }
    
}
