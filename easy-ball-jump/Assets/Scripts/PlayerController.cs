using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerController : MonoSingleton<PlayerController> {

    bool _hasStartedPos = false;
    float _startedPosX;

    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start() {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _rigidbody.velocity += new Vector3(0, 10f, 0);
    }

    // Update is called once per frame
    void Update() {
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
}
