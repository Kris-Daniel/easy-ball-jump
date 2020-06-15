using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public float xOffset;
    float _xStartedPos;
    bool _hasStartedPos = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
        }

        if (Input.GetAxis("Fire1") > 0f) {
            
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
