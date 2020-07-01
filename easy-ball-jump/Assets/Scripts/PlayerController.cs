using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Platforms;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
// test
public class PlayerController : MonoSingleton<PlayerController> {
    bool _hasStartedPos = false;
    float _startedPosX;
    
    [HideInInspector]
    public Rigidbody rigidbody;
    TrailRenderer _trailRenderer;
    
    public ParticleSystem particleSystem;

    public static Action<int> OnChangeScore;
    
    [SerializeField]
    float _impulse;

    void Start() {
        transform.position = new Vector3(0, 1, 0);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity += new Vector3(0, _impulse, 0);
        _trailRenderer = gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (rigidbody.velocity.y < 2f) {
            _trailRenderer.enabled = false;
        }
       else
       {
            _trailRenderer.enabled = true;
       }
        
        float xOffset = InputManager.Instance.xOffset;
        if (xOffset > 0.01f || xOffset < -0.01f) {
            if (!_hasStartedPos) {
                _hasStartedPos = true;
                _startedPosX = transform.position.x;
            }
            
            float edge = InputManager.Instance.screenBounds.x + transform.GetComponent<Renderer>().bounds.size.x / 2f;
            float newPosX = Mathf.Clamp(_startedPosX + xOffset, edge, -edge);
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
        }
        else {
            _hasStartedPos = false;
        }
        
    }

    void OnTriggerEnter(Collider col) {
        if (rigidbody.velocity.y < 0.01f) {
            PlatformBreakableController breakablePlatform = col.GetComponent<PlatformBreakableController>();
            if (breakablePlatform != null)
                Destroy(breakablePlatform.gameObject);
            else {
                PlatformController platformController = col.GetComponent<PlatformController>();
                if (platformController != null) {
                    rigidbody.velocity = new Vector3(0, _impulse, 0);
                    if(MusicManager.Instance != null)
                        MusicManager.Instance.PlayBallJumpSound();
                    Instantiate(particleSystem, transform.position, Quaternion.identity);
                }
            }
        }

        PlatformGridController platformGrid = col.gameObject.GetComponent<PlatformGridController>();
        if (platformGrid != null) {
            if(OnChangeScore != null && platformGrid.scoreToAdd > 0)
                OnChangeScore(platformGrid.scoreToAdd);
            platformGrid.scoreToAdd = 0;
        }
    }

    public void ResetOnChangeScore() {
        OnChangeScore = null;
    }
}
