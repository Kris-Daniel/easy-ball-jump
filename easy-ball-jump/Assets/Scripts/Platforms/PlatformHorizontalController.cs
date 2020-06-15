using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformHorizontalController : PlatformController
{    
    public PathType pathType = PathType.CatmullRom;
    Vector3[] _waypoints = new[] {
        new Vector3(PlatformPoolController.leftEdge, 0, 0),
        new Vector3(PlatformPoolController.rightEdge, 0, 0),
    };
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        int isRight = Random.Range(0, 2);
        if(isRight == 1)
            MoveRight();
        else
            MoveLeft();
    }

    void MoveRight() {
        transform.DOMoveX(5.5f, 4).SetSpeedBased().SetEase(Ease.Linear).OnComplete(MoveLeft);
    }
    void MoveLeft() {
        transform.DOMoveX(-5.5f, 4).SetSpeedBased().SetEase(Ease.Linear).OnComplete(MoveRight);
    }
    
}
