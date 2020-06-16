using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController> {

    bool _hasStartedPos = false;
    float _startedPosX;

    public Rigidbody rigidbody;
    BoxCollider _boxCollider;
    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity += new Vector3(0, 10f, 0);
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {
        /*if (rigidbody.velocity.y > 0.01f) {
            _boxCollider.enabled = false;
        } else if (rigidbody.velocity.y < 0.01f) {
            _boxCollider.enabled = true;
        }*/
        
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
