using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformVerticalController : PlatformController {
    bool _isMoveTop = false;
    float _moveCounter = 0f;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        
    }

    void Update() {
        if(_isMoveTop)
            MoveTop();
        else {
            MoveDown();
        }
    }

    void MoveTop() {
        transform.Translate(new Vector3(0, Time.deltaTime, 0), Space.World);
        _moveCounter += Time.deltaTime;
        if (_moveCounter > 1.2f) {
            _moveCounter = 0f;
            _isMoveTop = false;
        }
    }
    void MoveDown() {
        transform.Translate(new Vector3(0, -Time.deltaTime, 0), Space.World);
        _moveCounter -= Time.deltaTime;
        if (_moveCounter < -1.2f) {
            _moveCounter = 0f;
            _isMoveTop = true;
        }
    }
}
