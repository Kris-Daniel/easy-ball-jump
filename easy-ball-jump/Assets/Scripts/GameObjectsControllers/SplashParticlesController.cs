using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticlesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyItself", 1f);
    }

    void DestroyItself() {
        Destroy(gameObject);
    }
}
