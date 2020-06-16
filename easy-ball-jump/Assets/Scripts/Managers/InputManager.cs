using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public float xOffset;
    float _xStartedPos;
    bool _hasStartedPos = false;

    public Vector2 screenBounds;

    void Start() {
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        
        Vector2? posUI = null;
        if (Input.GetAxis("Fire1") > 0f)
            posUI = Input.mousePosition;
        if (Input.touchCount > 0)
            posUI = Input.GetTouch(0).position;
        
        if (posUI != null) {
            Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity)) {
                if (!_hasStartedPos) {
                    _hasStartedPos = true;
                    _xStartedPos = hit.point.x;
                }

                xOffset = hit.point.x - _xStartedPos;
            }
            
        }
        else {
            xOffset = 0f;
            _hasStartedPos = false;
        }
        
    }
}
