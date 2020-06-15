using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformHorizontalController : PlatformController
{    
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
        transform.DOMoveX(PlatformPoolController.leftEdge, 4).SetSpeedBased().SetEase(Ease.Linear).OnComplete(MoveLeft);
    }
    void MoveLeft() {
        transform.DOMoveX(PlatformPoolController.rightEdge, 4).SetSpeedBased().SetEase(Ease.Linear).OnComplete(MoveRight);
    }
    
}
