﻿using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController> {

    bool _hasStartedPos = false;
    float _startedPosX;

    public Rigidbody rigidbody;
    TrailRenderer _trailRenderer;
    void Start() {
        transform.position = new Vector3(0, 1, 0);
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity += new Vector3(0, 10f, 0);
        _trailRenderer = gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (rigidbody.velocity.y < 0f)
            _trailRenderer.enabled = false;
       else
            _trailRenderer.enabled = true;
        
        float xOffset = InputManager.Instance.xOffset;
        if (xOffset > 0.01f || xOffset < -0.01f) {
            if (!_hasStartedPos) {
                _hasStartedPos = true;
                _startedPosX = transform.position.x;
            }

            float newPosX = Mathf.Clamp(_startedPosX + xOffset, -6f, 6f);
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
            else
                rigidbody.velocity = new Vector3(0, 10f, 0);
        }
        
    }
}
